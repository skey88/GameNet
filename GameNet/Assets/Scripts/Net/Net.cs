using UnityEngine;
using System.Threading;
using System;
using System.Collections.Generic;
using com.sporger.server.proto.model;

namespace Stars
{
    public partial class Net : SingletonNewFirst<Net>, IGameSubSystem
    {
        private ClientSocket[] socketList_;
        ClientNetStats _netStats;
        private List<byte[]> send_MessageDataPoolAL;
        //优先发送的队列
        //public static List<byte[]> send_MessageDataPoolAL_HighPriority;
        private ulong seq_ = 1;
        private static Thread thread;
        public delegate void DisConnectCallback();
        public DisConnectCallback gameServerLostConnectCallback = null;
        const int MaxConnectNum = 1;

        string _userId;
        string _session;
        Timer _sendHeartBeatTimer = null;
        const float SendHeartBeatTime = 60;
        const float PingTime = 1;

        /// <summary>
        /// 执行更新操作
        /// </summary>
        bool isUpdate_ = true;
        /// <summary>
        /// 是否正在重新登录，从连接游戏服务器到连接游戏服务器成功,并且与服务器的登录有关协议收发完毕，
        /// 在发送所有连接成功后发送之前未发出的网络包之前结束
        /// </summary>
        bool _relogin = false;
        int _beginSendReloginMsg = 0;
        bool _isShowNetLostConn = false;

        /// <summary>
        /// 用来存放正常发送的消息，不包含重连过程中任何消息
        /// </summary>
        SortedDictionary<ulong, SendMsgInfo> _sendBuffs = new SortedDictionary<ulong, SendMsgInfo>();

        /// <summary>
        /// 网络异常时的消息缓存
        /// </summary>
        SortedDictionary<ulong, SendMsgInfo> _sendBuffs_NetInvalid = new SortedDictionary<ulong, SendMsgInfo>();
        /// <summary>
        /// 重连过程中发送的登录消息,只限于要登录的游戏服务器
        /// </summary>
        //SortedDictionary<ulong, SendMsgInfo> _sendBuffs_Relogin = new SortedDictionary<ulong, SendMsgInfo>();
        /// <summary>
        /// 是否正在准备重新连接，从请求重连游戏服务器到开始连接服务器为止,这个期间停止发送循环发送任何消息
        /// </summary>
        bool _needReconnect = false;
        /// <summary>
        /// 等待用户确认重连
        /// </summary>
        bool _reloginGameWaitUserConfirm = false;
        //重新连接的次数计数
        short _reLoginGameCount = 0;
        //清除重连计数的时间，秒为单位
        const float _clearReloginGameCountTime = 1;
        //重连准备时间，如果大于退避时间就开始重连
        float _reloginPrepareTime = 0;
        //用于统计指数退避时间的标记
        bool _reloginReady = false;

        public const float baseT = 51.2f * 0.000001f;
        public const float reSendMax = 1;

        public delegate void ReConnectSeverSucCallBack(ServerNumber server);
        public ReConnectSeverSucCallBack _reConnectSeverSucCallBack;
        object sendlock_ = new object();//Unity3d版本不稳定，不能使用Lock
        //LostConnBackToLoginTimer lostConnBackToLoginTimer_;
        /// <summary>
        /// 发送消息后等待返回的超时设置
        /// </summary>
        public const float sendMsgTimeout_ = 10;
        /// <summary>
        /// 设置网络是否运转
        /// </summary>
        bool isEnabled_ = true;
        public delegate void SendMsgTimeoutCallback(PackHead packHead);
        SendMsgTimeoutCallback[] _sendMsgTimeoutCallback = new SendMsgTimeoutCallback[MaxConnectNum];
        public delegate void SendMsgTimeoutConfirmCallback();
        SendMsgTimeoutConfirmCallback[] _sendMsgTimeoutConfirmCallback = new SendMsgTimeoutConfirmCallback[MaxConnectNum];
        int reSendOtherServerMsgSvrId_ = 0;
        bool isNeedReSendOtherServerMsg = false;
        public Queue<sEvent_NetMessageData> _netMessageDataQueue = new Queue<sEvent_NetMessageData>();
        Ping ping = null;
        Timer pingTimer = null;
        float lastPingTime = -1;
        private string gameServerIp;
        float pingCountTime = 0;
        Action<float> notifyPingTime;

        bool _isLoginSucces = false;

        List<MessageType> _neednotReceiveMsg = new List<MessageType>();
        public void init()
        {
            socketList_ = new ClientSocket[MaxConnectNum];
            send_MessageDataPoolAL = new List<byte[]>();
            //send_MessageDataPoolAL_HighPriority = new List<byte[]>();
            seq_ = 1;
            NetObserver.addObservers(this);
            initNeednotReceiveMsg();
            thread = new Thread(LoopSendMessage);
            thread.IsBackground = true;
            thread.Start();
            //lostConnBackToLoginTimer_ = new LostConnBackToLoginTimer(RGGameLogic.backToLogin);
        }

        void initNeednotReceiveMsg()
        {
            _neednotReceiveMsg.Add(MessageType.REQ_CHARACTER_STATUS);
            _neednotReceiveMsg.Add(MessageType.REQ_MAZE_CHARACTER_STATUS);
            _neednotReceiveMsg.Add(MessageType.REQ_CITY_CHARACTER_STATUS);
            _neednotReceiveMsg.Add(MessageType.REQ_RAINBOW_RUN_CHARACTER_STATUS);
        }

        void checkReSendOtherSvrMsg()
        {
            if (isNeedReSendOtherServerMsg)
            {
                isNeedReSendOtherServerMsg = false;
                List<byte[]> resendCache = getSendListFromSendBuffer(reSendOtherServerMsgSvrId_);
                if (resendCache.Count > 0)
                {
                    //MsgBoxPara msgBoxPara = new MsgBoxPara(21002, 0,0,GlobalTipType.Ok, delegate ()
                    //{
                    //    reSendOtherServerMsgCallback(reSendOtherServerMsgSvrId_, resendCache);
                    //    setActivate(true);
                    //});
                    //ShowGloabalTip(msgBoxPara); 
                }
            }
        }

        public void update(float time)
        {
            if (!isUpdate_ || !isEnabled_) return;
            checkReSendOtherSvrMsg();
            reLoginGameUpdate();
            processReceive();
            if (_netStats == ClientNetStats.Valid || _relogin)
            {
                //lostConnBackToLoginTimer_.update();
                sendMsgTimeoutCheck();
            }
        }
 
        void processReceive()
        {
            int i = 0;
            while (_netMessageDataQueue.Count > 0)
            {
                lock (_netMessageDataQueue)
                {
                    sEvent_NetMessageData tmpNetMessageData = _netMessageDataQueue.Dequeue();
                    //if (Game.Get() != null)
                    //{
                    //    if (tmpNetMessageData._eventType != MessageType.NOTIFY_CHARACTER_STATUS && tmpNetMessageData._eventType != MessageType.SYNC_PLAYER_INSTANCE_POS)
                    //        TyLogger.Log("receive msg = " + tmpNetMessageData._eventType + " " + tmpNetMessageData._msgIndex + " " + tmpNetMessageData._errorcode);
                    //    try
                    //    {
                    //        Game.Get().SendNotification(tmpNetMessageData._eventType.ToString(), tmpNetMessageData);
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        TyLogger.Log(tmpNetMessageData._eventType + " msg error!" + e.ToString());
                    //    }
                    //    finally
                    //    {
                    //        if (tmpNetMessageData._msgIndex != 0 || tmpNetMessageData._eventType == MessageType.LOGIN_VALIDATE_RECONNECT)
                    //        {
                    //            UIHideWaiting();
                    //        }
                    //        checkIndex(tmpNetMessageData);
                    //        _sendBuffs.Remove(tmpNetMessageData._msgIndex);
                    //        //_sendBuffs_Relogin.Remove(tmpNetMessageData._msgIndex);
                    //    }
                    //}
                }
                if (++i >= 10) break;
            }
        }

        void checkIndex(sEvent_NetMessageData NetMessageData)
        {
            foreach (SendMsgInfo smi in _sendBuffs.Values)
            {
                PackHead packHead = (PackHead)NetDataFormatChange.BytesToStruct((byte[])smi._sendBuff, typeof(PackHead));
                if ((ushort)NetMessageData._eventType == packHead.cmd)
                {
                    if (NetMessageData._msgIndex != packHead.seq)
                    {
                        //弹出消息框显示序列号不对
                        //TyLogger.LogWarning(packHead.cmd + " message seq increct!");
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// 发送消息超时检测
        /// </summary>
        void sendMsgTimeoutCheck()
        {
            if (_sendBuffs.Count > 0)
            {
                SortedDictionary<ulong, SendMsgInfo>.Enumerator enumerator = _sendBuffs.GetEnumerator();
                enumerator.MoveNext();
                PackHead packHead = (PackHead)NetDataFormatChange.BytesToStruct((byte[])enumerator.Current.Value._sendBuff, typeof(PackHead));
                int serverId = getServerId(packHead.cmd);

                if (Time.time - enumerator.Current.Value._sendTime > sendMsgTimeout_)
                {
                    string debugStr = ((MessageType)packHead.cmd) + " can't receive.";
                    if (_sendMsgTimeoutCallback[serverId] != null)
                    {
                        _sendMsgTimeoutCallback[serverId](packHead);
                    }

                    if (serverId == (int)ServerNumber.Game)
                    {
                        _netStats = ClientNetStats.InValid;
                        socketList_[(int)ServerNumber.Game].endReceive();
                    }
                }
            }
        }

        void sendTimeOutCallback(int curSendMsgTimeoutServer)
        {
            setNetEnabled(true);
            if (curSendMsgTimeoutServer == (int)ServerNumber.Game)
            {
                //GameLogic gl = Game.Get().findObject<GameLogic>();
                //gl.postEvt(new FSMEvent_C("Login_Login"));
            }
            else
            {
                List<byte[]> resendCache = getSendListFromSendBuffer(curSendMsgTimeoutServer);
                if (resendCache.Count > 0)
                {
                    reSendOtherServerMsgCallback(curSendMsgTimeoutServer, resendCache);
                }
            }

            if (_sendMsgTimeoutConfirmCallback[curSendMsgTimeoutServer] != null)
            {
                _sendMsgTimeoutConfirmCallback[curSendMsgTimeoutServer]();
            }
        }

        //
        /// <summary>
        /// 设置网络是否可以接收发送消息
        /// </summary>
        /// <param name="enable"></param>
        public void setNetEnabled(bool enable)
        {
            isEnabled_ = enable;
        }
 
        /// <summary>
        /// 代表网络已经正常
        /// </summary>
        /// <param name="server"></param>
        public void reConnectSuccess(ServerNumber server)
        {
            reSendGameMsg(server);
            if(server == ServerNumber.Game)
            {
                _reLoginGameCount = 0;
            }
            if (_reConnectSeverSucCallBack != null)
            {
                _reConnectSeverSucCallBack(server);
            }
            _netStats = ClientNetStats.Valid;
        }

        void reLoginGameUpdate()
        {
            checkReconnect();
            if (_needReconnect)
            {
                _netStats = ClientNetStats.InValid;
                disConnect((int)ServerNumber.Game);
                //lostConnBackToLoginTimer_.beginTimer();
                lock (send_MessageDataPoolAL)
                {
                    Debug.Log("recevie error reconnect------------------------------------------------------ time = " + Time.realtimeSinceStartup);
                    //lostConnBackToLoginTimer_.stopTimer();
                    if (_reLoginGameCount == 0)
                    {
                        reConnectGameServer();
                    }
                    else if (_reLoginGameCount <= 2)
                    {
                        showConnectConfirm();
                    }
                    else
                    {
                        showQuitDialog();
                    }
                    _reLoginGameCount++;
                    moveSendBuffToNetInvalidCache();
                    send_MessageDataPoolAL.Clear();
                    //send_MessageDataPoolAL_HighPriority.Clear();
                    _needReconnect = false;
                }
            }
        }

        void checkReconnect()
        {
            if (_beginSendReloginMsg > 0)
            {
                _beginSendReloginMsg--;
                if (_beginSendReloginMsg == 0)
                {
                    //连接成功回调后，IsConnect()要过一阵子才会正确
                    if (socketList_[(int)ServerNumber.Game].IsConnect())
                    {
                        socketList_[(int)ServerNumber.Game].Receive();
                        //_sendBuffs_Relogin.Clear();
                        if (_isLoginSucces)
                        {
                            send_check_login_effective();
                        }
                    }
                    else
                    {
                        _needReconnect = true;
                        _netStats = ClientNetStats.InValid;
                    }
                }
            }
        }

        public void setActivate(bool activate)
        {
            isUpdate_ = activate;
        }
  
        private int getServerId(UInt16 cmd)
        {
            int connectNum = (int)ServerNumber.Game;
            return connectNum;
        }


        ulong getSeq()
        {
            return seq_++;
        }

        /// <summary>
        /// 重连相关协议发送消息专用
        /// </summary>
        /// <param name="cmd">消息号</param>
        /// <param name="obj">数据内容</param>
        /// <returns>返回消息序列号</returns>
        public ulong sendReloginMsg(MessageType cmd, ProtoBuf.IExtensible data)
        {
            Debug.Log("sendReloginMsg message cmd = " + cmd.ToString());
            ulong seq = 0;// getSeq();
            ClientSocket socket = socketList_[getServerId((ushort)cmd)];
            if (socket != null)
            {
                byte[] sendBuff = PackageMessage((ushort)cmd, seq, ProtoBuf_Serializer(data));
                _sendBuffs.Add(seq, new SendMsgInfo(sendBuff, Time.time));

                lock (send_MessageDataPoolAL)
                {
                    send_MessageDataPoolAL.Insert(0,sendBuff);
                }
                UIShowWaiting();
            }
            return seq;
        }

        public void InsertSendMessageToPool(List<byte[]> sendList)
        {
            lock (send_MessageDataPoolAL)
            {
                send_MessageDataPoolAL.InsertRange(0,sendList);
            }
        }
 
        /// <summary>
        /// 异步回调 发送
        /// </summary>
        /// <param name="skSocket"></param>
        /// <param name="s"></param>
        /// <param name="errorcode"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        int CallBack_Send(ClientSocket skSocket, bool s, ClientSocket.Erro_Socket errorcode, string exception)
        {
            if (errorcode != ClientSocket.Erro_Socket.SUCCESS)
            {
                Debug.Log("CallBack_Send" + s + errorcode.ToString() + exception);
                int i = 0;
                foreach (ClientSocket mySocket in socketList_)
                {
                    if (skSocket != null && mySocket == skSocket)
                    {
                        Debug.Log("connect " + i.ToString() + " disconnect");
                        if (i == (int)ServerNumber.Game)
                        {
                            //if (!(_relogin || _reloginGameWaitUserConfirm))
                            //{
                            //    _needReconnect = true;
                            //    _netStats = ClientNetStats.InValid;
                            //}
                            return 1;
                        }
                    }
                    i++;
                }
            }
            return 0;
        }


        void showConnectConfirm()
        {
            Debug.Log("showConnectConfirm");
            _reloginGameWaitUserConfirm = true;
            UIHideWaiting();
            //MsgBoxPara msgBoxPara = new MsgBoxPara(21002,21010,21008,GlobalTipType.YesNo, reConnectGameServer,Application.Quit);
            //ShowGloabalTip(msgBoxPara);
        }

        void showQuitDialog()
        {
            Debug.Log("showQuitDialog");
            UIHideWaiting();
            _reloginGameWaitUserConfirm = true;
            //MsgBoxPara msgBoxPara = new MsgBoxPara(21005,21011,0, GlobalTipType.Ok, Application.Quit);
            //ShowGloabalTip(msgBoxPara);
        }

        void reConnectGameServer()
        {
            Debug.Log("Begin reConnectGameServer");
            _relogin = true;
            _reloginGameWaitUserConfirm = false;
            disConnect((int)ServerNumber.Game);
            socketList_[(int)ServerNumber.Game].reConnect(reConnectGameServerCallback);
            UIShowWaiting();
        }

        void reConnectGameServerCallback(bool success,  ClientSocket.Erro_Socket error, string exception)
        {
            Debug.Log("reloginGameCallback " + success + " error = " + error);
            if(success)
            {
                _beginSendReloginMsg = 100;
            }
            else
            {
                _needReconnect = true;
                _netStats = ClientNetStats.InValid;
            }
            UIHideWaiting();
        }


        void send_check_login_effective()
        {
            Debug.Log("send_check_login_effective");
            login_validate_reconnect_in login_validate_reconnect_in = new login_validate_reconnect_in();
            login_validate_reconnect_in.session = _session;
            sendReloginMsg(MessageType.LOGIN_VALIDATE_RECONNECT, login_validate_reconnect_in);
        }

        public void reSendGameMsg(ServerNumber svrNum)
        {
            Debug.Log("reSendGameMsg");
            _relogin = false;
            //UIWaitingForceHide();
            List<byte[]> resendCache = getSendListFromSendBuffer((int)svrNum);
            for (int i = 0; i < resendCache.Count; i++)
            {
                byte[] curBuff = resendCache[i];
                PackHead packHead = (PackHead)NetDataFormatChange.BytesToStruct((byte[])curBuff, typeof(PackHead));
                ulong oriSeq = packHead.seq;
                _sendBuffs.Remove(oriSeq);
                if (packHead.cmd != (ushort)MessageType.LOGIN_VALIDATE_RECONNECT)
                {
                    //UIShowWaiting("wait", 2);
                    _sendBuffs.Add(oriSeq, new SendMsgInfo(curBuff, Time.time));
                }
            }            
            InsertSendMessageToPool(resendCache);
            //socketList_[(int)svrNum].clearSendCache();
        }
        /// <summary>
        /// 发送其它服务器未收到到消息,服务器断线后使用
        /// </summary>
        /// <param name="svrNum"></param>
        public void reSendOtherServerMsgCallback(int svrNum, List<byte[]> resendCache)
        {
            Debug.Log("reSendOtherServerMsg");
            UIWaitingForceHide();

            for (int i = 0; i < resendCache.Count; i++)
            {
                byte[] curBuff = resendCache[i];
                PackHead packHead = (PackHead)NetDataFormatChange.BytesToStruct((byte[])curBuff, typeof(PackHead));
                ulong oriSeq = packHead.seq;
                _sendBuffs.Remove(oriSeq);
                _sendBuffs.Add(oriSeq, new SendMsgInfo(curBuff, Time.time));
                UIShowWaiting();
            }
            resetSendBuffSendTime();
            InsertSendMessageToPool(resendCache);
            //socketList_[(int)svrNum].clearSendCache();
        }

        public void resetSendBuffSendTime()
        {
            foreach (SendMsgInfo smi in _sendBuffs.Values)
            {
                smi._sendTime = Time.time;
            }
        }

        public bool connect(int id, string ip, int port, ClientSocket.CallBack_Connect callback_connect)
        {
            Debug.Log("connect " + id.ToString() + " " + ip + " " + port.ToString());
            if(id == (int)ServerNumber.Game)
            {
                gameServerIp = ip;
            }
            if (!isEnabled_) return false;
            if (id > MaxConnectNum - 1)
            {
                Debug.Log("connect fail due to over MaxConnectNum");
                return false;
            }

            if (socketList_[id] == null)
            {
                socketList_[id] = new ClientSocket();
                socketList_[id]._id = id;
                //重连成功后发送未收到的消息，只针对非游戏服务器
                socketList_[id]._reConnectSendMsg = sendTimeOutCallback;
                Debug.Log("connect new " + id.ToString() + " " + ip + " " + port.ToString());
            }

            if (socketList_[id].IsConnect())
            {
                if (callback_connect != null)
                {
                    callback_connect(true, ClientSocket.Erro_Socket.SUCCESS, "");
                    return true;
                }
            }
            
            initHeartBeatTimer();
            initPing();
            socketList_[id].Async_Connect(ip, port, callback_connect, CallBack_Receive, CallBack_OnDisconnect);
            return true;
        }

        public void disConnect(int id)
        {
            if (socketList_[id] != null)
            {
                if (socketList_[id].IsConnect())
                {
                    socketList_[id].Async_Disconnect(callBack_Disconnect);
                }
            }
        }
        /// <summary>
        /// 被动断开回调
        /// </summary>
        /// <param name="skSocket"></param>
        void CallBack_OnDisconnect(ClientSocket skSocket)
        {
            Debug.Log("CallBack_OnDisconnect");
            int i = 0;
            foreach (ClientSocket mySocket in socketList_)
            {
                if (skSocket != null && mySocket == skSocket)
                {
                    Debug.Log("connect " + i.ToString() + " disconnect");
                    if (i == (int)ServerNumber.Game)
                    {
                        if (gameServerLostConnectCallback != null) gameServerLostConnectCallback();
                    }
                }
                i++;
            }
        }
        /// <summary>
        /// 主动断开回调
        /// </summary>
        /// <param name="skSocket"></param>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="exception"></param>
        void callBack_Disconnect(ClientSocket skSocket, bool success, ClientSocket.Erro_Socket error, string exception)
        {
            Debug.Log("callBack_Disconnect " + success.ToString() + " " + error.ToString() + " " + exception);
        }

        void CallBack_Receive(ClientSocket skSocket, bool s, ClientSocket.Erro_Socket errorcode, string exception, sEvent_NetMessageData messageData, string strMessage)
        {
            if (socketList_[(int)ServerNumber.Game] == skSocket)
            {
                CallBack_Receive_Game(skSocket, s, errorcode, exception, messageData, strMessage);
            }
            else
            {
                CallBack_Receive_Other(skSocket, s, errorcode, exception, messageData, strMessage);
            }
        }

        void CallBack_Receive_Other(ClientSocket skSocket, bool s, ClientSocket.Erro_Socket errorcode, string exception, sEvent_NetMessageData messageData, string strMessage)
        {
            if (errorcode != ClientSocket.Erro_Socket.SUCCESS)
            {
                Debug.Log("CallBack_Receive" + s + errorcode.ToString() + exception + strMessage);
                if (isEnabled_ == false || isRelogin() || _needReconnect) return;//如果当前正在处理断线重连则退出
                                                                               //is SomeMsg Did't receive
                int serverid = getServerIdFromClientSocket(skSocket);
                reSendOtherServerMsg(serverid);
            }
            else
            {
                PutGetMessageToPool(messageData);
            }
        }

        void reSendOtherServerMsg(int serverid)
        {
            if (serverid != -1)
            {
                List<byte[]> resendCache = getSendListFromSendBuffer(serverid);
                if (resendCache.Count > 0)
                {
                    //禁止处理超时等自动事件,只是停止网络模块的更新，所以需要不能有连接和发送的函数调用,只限于其它服务器，因为游戏服务器会在加载场景时禁用它，应避免出现无法回复到正确的值
                    setActivate(false);
                    reSendOtherServerMsgSvrId_ = serverid;
                    isNeedReSendOtherServerMsg = true;
                }
            }
        }


        List<byte[]> getSendListFromSendBuffer(int serverid)
        {
            List<byte[]> resendCache = new List<byte[]>();
            foreach (SendMsgInfo smi in _sendBuffs_NetInvalid.Values)
            {
                PackHead packHead = (PackHead)NetDataFormatChange.BytesToStruct((byte[])smi._sendBuff, typeof(PackHead));
                int serverMsgToSend = getServerId(packHead.cmd);
                if (serverMsgToSend == serverid)
                {
                    resendCache.Add(smi._sendBuff);
                }
            }
            removeSendInfoFromSendBuffer(resendCache);
            return resendCache;
        }

        void removeSendInfoFromSendBuffer(List<byte[]> resendCache)
        {
            foreach (byte[] data in resendCache)
            {
                PackHead packHead = (PackHead)NetDataFormatChange.BytesToStruct(data, typeof(PackHead));
                _sendBuffs_NetInvalid.Remove(packHead.seq);
            }
        }

        void moveSendBuffToNetInvalidCache()
        {
            foreach(KeyValuePair < ulong, SendMsgInfo > kv in _sendBuffs)
            {
                _sendBuffs_NetInvalid.Add(kv.Key,kv.Value);
            }
            _sendBuffs.Clear();
        }

        int getServerIdFromClientSocket(ClientSocket skSocket)
        {
            int id = -1;
            for (int i = 0; i < MaxConnectNum; i++)
            {
                if (socketList_[i] == skSocket)
                {
                    id = i;
                }
            }
            return id;
        }

        void CallBack_Receive_Game(ClientSocket skSocket, bool s, ClientSocket.Erro_Socket errorcode, string exception, sEvent_NetMessageData messageData, string strMessage)
        {
            if (errorcode != ClientSocket.Erro_Socket.SUCCESS)
            {
                Debug.Log("CallBack_Receive" + s + errorcode.ToString() + exception + strMessage);

                if(errorcode == ClientSocket.Erro_Socket.SOCKET_UNCONNECT || errorcode == ClientSocket.Erro_Socket.RECEIVE_UNSUCCESS_UNKNOW)
                {
                    if (_netStats == ClientNetStats.InValid)
                    {
                        UIHideWaiting();//只有在发重登录消息期间出现
                    }
                    {
                        _needReconnect = true;
                        _netStats = ClientNetStats.InValid;
                    }
                    //lostConnBackToLoginTimer_.beginTimer();
                }
            }
            else
            {
                PutGetMessageToPool(messageData);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="get_Message"></param>
        void PutGetMessageToPool(sEvent_NetMessageData messageData)
        {
            lock(_netMessageDataQueue)
            {
                _netMessageDataQueue.Enqueue(messageData);
            }
        }

        /// <summary>
        /// 发送消息入池
        /// </summary>
        /// <param name="type1"></param>
        /// <param name="type2"></param>
        /// <param name="data"></param>
        public void PutMessageToPool(byte[] data)
        {
            lock (send_MessageDataPoolAL)
            {
                send_MessageDataPoolAL.Add(data);
            }
        }

        void LoopSendMessage()
        {
            while (true)
            {
                try
                {
                    sendMsgInPool(send_MessageDataPoolAL, 0);
                }
                catch
                {
                    //TyLogger.LogError("LoopSendMessage err");
                }
                Thread.Sleep(10);
            }
        }


        void sendMsgInPool(List<byte[]> pool, int priority)
        {
            byte[] data = null;
            lock (pool)
            {
                if (pool.Count == 0) return;
                data = pool[0];
                pool.RemoveAt(0);
            }
            PackHead packHead = (PackHead)NetDataFormatChange.BytesToStruct(data, typeof(PackHead));
            //Debug.Log("loopsendmsg " + priority + " " + packHead.cmd);
            ClientSocket socket = socketList_[getServerId(packHead.cmd)];
            if (socket != null)
            {
                int result = socket.Async_Send(data, CallBack_Send);
            }
        }

        public byte[] PackageMessage(UInt16 cmd, UInt64 seq, byte[] data)
        {
            byte[] messageData = NetDataFormatChange.SocketDataToBytes(NetDataFormatChange.BytesToSocketData((MessageType)cmd, data,_userId, seq));
            return messageData;
        }
 
        public bool isRelogin()
        {
            return _relogin;
        }

        public void disConnectAll()
        {
            for (int i = 0; i < socketList_.Length; i++)
            {
                if (socketList_[i] != null)
                {
                    socketList_[i].Async_Disconnect(null);
                }
            }
        } 
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="protocalType">消息类型</param>
        /// <param name="data">消息内容</param>
        /// <returns>返回消息信息</returns>
        public SendMsgInfo sendMsg(MessageType protocalType, ProtoBuf.IExtensible data)
        {
            SendMsgInfo sendMsgInfo = new SendMsgInfo(null, Time.time);
            if (!isEnabled_ && _netStats == ClientNetStats.InValid) return sendMsgInfo;

            bool canReceive = true;
            for(int i = 0;i < _neednotReceiveMsg.Count;i++)
            {
                if(protocalType == _neednotReceiveMsg[i])
                {
                    canReceive = false;
                }
            }
            if(canReceive)
            {

            }
                //TyLogger.Log("sendmsg = " + protocalType);
            ulong seq = getSeq();
            int serverId = getServerId((ushort)protocalType);
            ClientSocket socket = socketList_[serverId];
            if (socket != null)
            {
                byte[] sendBuff = PackageMessage((ushort)protocalType, seq, ProtoBuf_Serializer(data));
                if (_netStats == ClientNetStats.Valid)
                    PutMessageToPool(sendBuff);

                if (canReceive)
                {
                    sendMsgInfo._sendBuff = sendBuff;
                    if(_netStats == ClientNetStats.Valid)
                    {
                        _sendBuffs.Add(seq, sendMsgInfo);
                        UIShowWaiting("wait", 2);
                    }
                    //else
                    //{
                    //    _sendBuffs_NetInvalid.Add(seq, sendMsgInfo);
                    //}
                }
            }
            return sendMsgInfo;
        }
    }
}