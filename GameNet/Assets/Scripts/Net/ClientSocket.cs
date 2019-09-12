using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Stars
{
    public class ClientSocket
    {
        public delegate void CallBack_Connect(bool success, Erro_Socket error, string exception);
        public delegate int CallBack_Send(ClientSocket skSocket, bool success, Erro_Socket error, string exception);
        public delegate void CallBack_Receive(ClientSocket skSocket, bool success, Erro_Socket error, string exception, sEvent_NetMessageData messageData, string str_Message);
        public delegate void CallBack_Disconnect(ClientSocket skSocket, bool success, Erro_Socket error, string exception);
        public delegate void CallBack_OnDisconnect(ClientSocket skSocket);
        /// <summary>
        /// 重连回调
        /// </summary>
        CallBack_Connect _callBack_ReConnect;
        /// <summary>
        /// 连接回调
        /// </summary>
        public CallBack_Connect callBack_Connect;
        /// <summary>
        /// 发送回调
        /// </summary>
        public CallBack_Send callBack_Send;
        /// <summary>
        /// 获取消息回调
        /// </summary>
        public CallBack_Receive callBack_Receive;
        /// <summary>
        /// 断开连接回调
        /// </summary>
        public CallBack_Disconnect callBack_Disconnect;

        /// <summary>
        /// 关于断开连接通知
        /// </summary>
        public CallBack_OnDisconnect callBack_OnDisconnect;

        private Erro_Socket error_Socket = 0;
        public byte[] dataLenghbyte = new byte[4];
        private int receiveDataLength = 0;//当前接收长度
        private int allDataLengh = 0; //这类数据总长度
        private byte[] receiveDataAL;//数据拼接用
        public class SendBuffer
        {
            public byte[] buff;
            public CallBack_Send sendcallback;
        }
        //保存未加密的消息数据,暂未使用
        //public List<SendBuffer> sendCache;
        public enum Erro_Socket
        {
            SUCCESS = 0,                       //成功
            TIMEOUT = 1,                       //超时
            SOCKET_NULL = 2,                   //套接字为空
            SOCKET_UNCONNECT = 3,              //套接字未连接
            CONNECT_UNSUCCESS_UNKNOW = 4,      //连接失败未知错误
            CONNECT_CONNECED_ERROR = 5,        //重复连接错误
            SEND_UNSUCCESS_UNKNOW = 6,         //发送失败未知错误
            RECEIVE_UNSUCCESS_UNKNOW = 7,      //收消息未知错误
            DISCONNECT_UNSUCCESS_UNKNOW = 8,   //断开连接未知错误
        }


        private Socket clientSocket;
        private string addressIP;
        private int port;
        private int countTmp = 0;
        private bool isReceiveHalfHead = false;
        int iAsync_ReConnect = 0;
        public int _id = 0;

        public delegate void ReConnectSendMsg(int serverId);
        public ReConnectSendMsg _reConnectSendMsg = null;

        public string AddressIP { get { return addressIP; } }
        public int Port { get { return port; } }
        StateObject stateObject_;

        ConnectTask connectTask_ = null;
        /// <summary>
        /// 非游戏服务器重连判断
        /// </summary>
        public bool isReConnecting { get; set; }

        private DataBuffer _databuffer = new DataBuffer(8192);

        byte[] _tmpReceiveBuff = new byte[8192];
        private IAsyncResult _asyncReceive;

        public ClientSocket()
        {
            //sendCache = new List<SendBuffer>();
            stateObject_ = new StateObject(8192, null);
            isReConnecting = false;
        }
        public bool IsConnect()
        {
            bool isConnect = false;
            if (clientSocket == null)
            {
                return isConnect;
            }
            return clientSocket.Connected;
        }

        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="ip"> IP</param>
        /// <param name="port">port</param>
        /// <param name="callback_Connect">连接回调</param>
        /// <param name="callBack_Receive">接收消息回调</param>
        public void Async_Connect(string ip, int port, CallBack_Connect callback_Connect, CallBack_Receive callBack_Receive, CallBack_OnDisconnect callBack_onDisConnect)
        {
            error_Socket = Erro_Socket.SUCCESS;
            this.callBack_Connect = callback_Connect;
            this.callBack_Receive = callBack_Receive;
            this.callBack_OnDisconnect = callBack_onDisConnect;
            if (clientSocket != null && clientSocket.Connected && this.callBack_Connect != null)
            {
                this.callBack_Connect(false, Erro_Socket.CONNECT_CONNECED_ERROR, "");//重复连接错误
            }
            else if (clientSocket == null || !clientSocket.Connected)
            {
                addressIP = ip;
                this.port = port;
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, port);
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                stateObject_.setSocket(clientSocket);
                //clientSocket.ReceiveTimeout = 1000;IOS IL2CPP编译时每当连接会接收到Recive的回调，执行EndReceive时报Block异常，网络也会断掉
                clientSocket.SendTimeout = 1000;
                clientSocket.LingerState = new LingerOption(true, 0);//close后立即清除发送缓存
                IAsyncResult asyncConnect = clientSocket.BeginConnect(ipEndpoint, new AsyncCallback(connectCallback), clientSocket);
            }

        }

        /// <summary>
        /// 连接回调
        /// </summary>
        /// <param name="asyncConnect"></param>
        private void connectCallback(IAsyncResult asyncConnect)
        {
            try
            {
                Socket clientSocket = (Socket)asyncConnect.AsyncState;
                clientSocket.EndConnect(asyncConnect);
                // arriving here means the operation completed
                // (asyncConnect.IsCompleted = true) but not necessarily successfully
                if (clientSocket.Connected == false)
                {
                    Debug.Log("连接失败");
                    error_Socket = Erro_Socket.CONNECT_UNSUCCESS_UNKNOW;
                    return;
                }
                else
                {
                    Debug.Log("连接成功");
                    Receive();//开始接受消息
                }
                if (callBack_Connect != null)//回调
                {
                    callBack_Connect(clientSocket.Connected, error_Socket, "");
                }
            }
            catch (Exception e)
            {
                if (callBack_Connect != null)//回调
                {
                    callBack_Connect(false, Erro_Socket.CONNECT_UNSUCCESS_UNKNOW, e.ToString());
                }
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                clientSocket = null;
            }

        }

        /// <summary>
        /// 发送byte[]类型数据
        /// </summary>
        /// <param name="sendBuffer"></param>
        /// <param name="callBack_Send"></param>
        /// <return>0为无错，1为错误</return> 
        public int Async_Send(byte[] sendBuffer, CallBack_Send callBack_Send)
        {
            error_Socket = Erro_Socket.SUCCESS;
            this.callBack_Send = callBack_Send;
            if (clientSocket == null)
            {
                error_Socket = Erro_Socket.SOCKET_NULL;
                Debug.Log("套接字为空，发送失败");
                sendErrorProcess(sendBuffer, callBack_Send);
                return 1;
            }
            else if (!clientSocket.Connected)
            {
                error_Socket = Erro_Socket.SOCKET_UNCONNECT;
                Debug.Log("未连接，发送失败");
                sendErrorProcess(sendBuffer, callBack_Send);
                return 1;
            }
            else
            {
                byte[] encrypedSendBuff = Stars.Encryption.NetMsgEncryp(sendBuffer);
                IAsyncResult asyncSend = clientSocket.BeginSend(encrypedSendBuff, 0, encrypedSendBuff.Length, SocketFlags.None, new AsyncCallback(sendCallback), clientSocket);
                //Debug.LogError("endSend");
                //if (writeDot(asyncSend) == false)
                //{
                //    Debug.Log("发送超时");
                //    if (clientSocket != null)
                //    {
                //        //clientSocket.Shutdown(SocketShutdown.Both);不需要确保缓冲区的东西发送完，相反，要立即释放
                //        clientSocket.Close();
                //        clientSocket = null;
                //    }
                //    sendErrorProcess(Stars.Encryption.NetMsgDecryp(sendBuffer), callBack_Send);
                //    return 1;
                //}
            }
            return 0;
        }

        void sendErrorProcess(byte[] sendBuffer, CallBack_Send callBack_Send)
        {
            int result = callBack_Send(this, false, error_Socket, "");
            SendBuffer sendBuff = new SendBuffer();
            sendBuff.buff = sendBuffer;
            sendBuff.sendcallback = callBack_Send;
            //sendCache.Add(sendBuff);
            if (result != 1)
            {
                //如果是其它服务器
                addConnectTask();
            }
        }
        /// <summary>
        /// 非游戏服务器重连回调
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="exception"></param>
        void reConnectCallback(bool success, ClientSocket.Erro_Socket error, string exception)
        {
            Debug.Log("reConnectCallback " + success + " " + error + " " + exception);
            if (success)
            {
                //会在重连成功后调用private void connectCallback(IAsyncResult asyncConnect)
                isReConnecting = false;
                if (_reConnectSendMsg != null)
                {
                    _reConnectSendMsg(_id);
                }
            }
            else
            {
                //MsgBoxPara msgBoxPara = new MsgBoxPara(21002, 21010,0,GlobalTipType.Ok, reConnectCallbackMsgboxCallback);
                //if (Game.Get() != null)
                //{
                //    Game.Get().SendNotification(RGGameGlobalEventType.SHOW_GLOBAL_TIP, msgBoxPara);
                //}
            }
        }

        void reConnectCallbackMsgboxCallback()
        {
            addConnectTask();
        }
        /// <summary>
        /// 增加重连任务，目前应用于非游戏服务器
        /// </summary>
        public void addConnectTask()
        {
            isReConnecting = true;
            removeConnectTask();
            connectTask_ = new ConnectTask(this._id, this.addressIP, this.port, reConnectCallback);
            TaskManager taskMgr = Game.Get().findObject<TaskManager>();
            if (taskMgr != null)
            {
                taskMgr.addTask(connectTask_);
            }
        }

        public void removeConnectTask()
        {
            if (connectTask_ != null)
            {
                TaskManager taskMgr = Game.Get().findObject<TaskManager>();
                if (taskMgr != null)
                {
                    taskMgr.removeTask(connectTask_);
                }
                connectTask_ = null;
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="callBack_Disconnect"></param>
        public void Async_Disconnect(CallBack_Disconnect callBack_Disconnect)
        {
            try
            {
                error_Socket = Erro_Socket.SUCCESS;
                this.callBack_Disconnect = callBack_Disconnect;
                if (clientSocket == null)
                {
                    error_Socket = Erro_Socket.SOCKET_NULL;
                    if (callBack_Disconnect != null)
                        callBack_Disconnect(this, true, error_Socket, "");
                    Debug.Log("套接字为空，断开失败");
                }
                else if (!clientSocket.Connected)
                {
                    error_Socket = Erro_Socket.SOCKET_UNCONNECT;
                    if (callBack_Disconnect != null)
                        callBack_Disconnect(this, true, error_Socket, "");
                    Debug.Log("已经断开连接，断开失败");
                }
                else
                {
                    Debug.Log("准备开始断开");
                    IAsyncResult asyncDisconnect = clientSocket.BeginDisconnect(false, new AsyncCallback(disconnectCallback), clientSocket);
                    clientSocket = null;
                    //writeDot(asyncDisconnect);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }


        }

        /// <summary>
        /// 断开连接回调
        /// </summary>
        /// <param name="asyncDisconnect"></param>
        private void disconnectCallback(IAsyncResult asyncDisconnect)
        {
            Debug.Log("disconnectCallback");
            try
            {
                Socket clientSocket = (Socket)asyncDisconnect.AsyncState;
                clientSocket.EndDisconnect(asyncDisconnect);
                clientSocket.Close();
                clientSocket = null;

                if (callBack_Disconnect != null)//回调
                {
                    Debug.Log("成功断开连接");
                    callBack_Disconnect(this, true, error_Socket, "");
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
                if (callBack_Disconnect != null)//回调
                {
                    Debug.Log("断开失败");
                    callBack_Disconnect(this, true, Erro_Socket.DISCONNECT_UNSUCCESS_UNKNOW, e.ToString());
                }

            }
        }

        /// <summary>
        /// 发送消息回调
        /// </summary>
        /// <param name="asyncSend"></param>
        private void sendCallback(IAsyncResult asyncSend)
        {
            try
            {
                Socket clientSocket = (Socket)asyncSend.AsyncState;
                int bytesSent = clientSocket.EndSend(asyncSend);
                if (callBack_Send != null)//回调
                {
                    callBack_Send(this, true, error_Socket, "");
                }

            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
                if (callBack_Send != null)//回调
                {
                    callBack_Send(this, true, Erro_Socket.SEND_UNSUCCESS_UNKNOW, e.ToString());
                }
            }

        }

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="callBack_Receive"></param>
        public void Receive()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                stateObject_.resetBuffer();
                _asyncReceive = clientSocket.BeginReceive(stateObject_.sBuffer, 0, stateObject_.sBuffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), stateObject_);
            }

        }

        public void endReceive()
        {
            if(clientSocket != null && _asyncReceive != null)
            {
                clientSocket.Close();
            }
        }

        /// <summary>
        /// 获取消息回调
        /// </summary>
        /// <param name="asyncReceive"></param>
        private void receiveCallback(IAsyncResult asyncReceive)
        {
            try
            {
                StateObject stateObject = (StateObject)asyncReceive.AsyncState;
                if (stateObject.sSocket == null)
                {

                    callBack_Receive(this, false, Erro_Socket.SOCKET_NULL, "", null, "");
                    Debug.Log("套接字为空，获得消息失败");
                    return;
                }
                else if (!stateObject.sSocket.Connected)
                {
                    callBack_Receive(this, false, Erro_Socket.SOCKET_UNCONNECT, "", null, "");//连接断开
                    Debug.Log("连接断开");
                    return;
                }
                int receiveLength = stateObject.sSocket.EndReceive(asyncReceive); //返回实际获得数据长度length
                //TyLogger.Log("receiveLength = " + receiveLength);
                if (receiveLength == 0)
                {
                    clientSocket = null;

                    callBack_Receive(this, false, Erro_Socket.SOCKET_UNCONNECT, "", null, "");//连接断开
                    Debug.Log("收到字节数为0，连接断开");

                    if (callBack_OnDisconnect != null)
                        callBack_OnDisconnect(this);
                    return;
                }
                
                MemCpy(_tmpReceiveBuff, stateObject.sBuffer, 0, receiveLength);

                //for(int i = 0;i < receiveLength;i++)
                //{
                //    Debug.Log(_tmpReceiveBuff[i]);
                //}

                sSocketData _socketData = new sSocketData();
                _databuffer.AddBuffer(_tmpReceiveBuff, receiveLength);//将收到的数据添加到缓存器中
                while (_databuffer.GetData(out _socketData))//取出一条完整数据
                {
                    sEvent_NetMessageData tmpNetMessageData = new sEvent_NetMessageData();
                    tmpNetMessageData._eventType = _socketData._protocallType;
                    tmpNetMessageData._msgIndex = _socketData._msgIndex;
                    tmpNetMessageData._errorcode = _socketData._errorCode;
                    tmpNetMessageData._eventData = Stars.Encryption.NetMsgDecryp(_socketData._data);


                    if (callBack_Receive != null)//回调
                    {
                        callBack_Receive(this, true, error_Socket, "", tmpNetMessageData, null);
                    }
                    //TyLogger.Log("receive message " + tmpNetMessageData._eventType);
                }

                //if (isReceiveHalfHead)//头只有一半
                //{
                //    isReceiveHalfHead = false;
                //    MemCpy(receiveDataAL, byteTMP, receiveDataLength);
                //    receiveDataLength += receiveLength;

                //}
                //else if (receiveDataLength == 0)//第一次接收该类型
                //{
                //    DismantleDataWithHead(byteTMP);
                //}
                //else//上次没接收完(zhong途，没头)
                //{
                //    DismantleDataWithoutHead(byteTMP);
                //}
            }
            catch (Exception e)
            {
                if (callBack_Receive != null)//回调
                {
                    callBack_Receive(this, false, Erro_Socket.RECEIVE_UNSUCCESS_UNKNOW, e.ToString(), null, "");
                }
            }
            Receive();
        }

        //public static void StrCpy(byte[] des, byte[] sou)
        //{
        //    int start = 0;
        //    if (des == null || sou == null)
        //    {
        //        return;
        //    }
        //    for (int a = 0; a < sou.Length; ++a)
        //    {
        //        if (des.Length > start + a)
        //        { des[start + a] = sou[a]; }
        //    }
        //    if (sou.Length < des.Length)
        //    {
        //        des[sou.Length] = 0;
        //    }
        //}

        //public static void MemCpy(byte[] des, byte[] sou, int start = 0)
        //{
        //    if (des == null || sou == null)
        //    {
        //        return;
        //    }
        //    for (int a = 0; a < sou.Length; ++a)
        //    {
        //        if (des.Length > start + a)
        //        { des[start + a] = sou[a]; }

        //    }
        //}

        public static void MemCpy(byte[] des, byte[] sou, int start, int length)
        {
            for (int a = 0; a < length; ++a)
            {
                des[start + a] = sou[a];
            }
        }

        //public static void MemCpy(byte[] des, byte[] sou, int start1, int start2, int length)
        //{
        //    if (des.Length - start1 < length || sou.Length - start2 < length)
        //    {
        //        return;
        //    }
        //    for (int a = 0; a < length; ++a)
        //    {
        //        des[start1 + a] = sou[start2 + a];
        //    }
        //}
        //void DismantleDataWithHead(byte[] allData)
        //{
        //    try
        //    {
        //        if (allData.Length < 4)//头只有一半
        //        {
        //            isReceiveHalfHead = true;
        //            MemCpy(receiveDataAL, allData, receiveDataLength);
        //            receiveDataLength += allData.Length;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < 4; i++)
        //            {
        //                dataLenghbyte[i] = 0;
        //            }

        //            if (Stars.Encryption._isUseEncryption)
        //            {
        //                for (int a = 0; a < 4; ++a)
        //                {
        //                    dataLenghbyte[a] = (byte)(allData[a] ^ Stars.Encryption.key[a % Stars.Encryption.key.Length]);
        //                }
        //            }
        //            else
        //            {
        //                for (int a = 0; a < 4; ++a)
        //                {
        //                    dataLenghbyte[a] = allData[a];
        //                }
        //            }

        //            allDataLengh = NetDataFormatChange.byteToInt(dataLenghbyte) + 4;
        //            receiveDataAL = new byte[allDataLengh];
        //            if (allData.Length == allDataLengh)//一次刚好接完
        //            {
        //                //receiveDataAL.Add(allData);
        //                MemCpy(receiveDataAL, allData, receiveDataLength);
        //                receiveDataLength += allData.Length;
        //                ReceiveMessageOver();
        //            }
        //            else if (allData.Length > allDataLengh)//本次接完还有别的数据
        //            {
        //                MemCpy(receiveDataAL, allData, receiveDataLength, allDataLengh);
        //                receiveDataLength += allData.Length;
        //                int remainDataLength = allData.Length - allDataLengh;
        //                ReceiveMessageOver();


        //                byte[] data = new byte[remainDataLength];
        //                for (int a = 0; a < remainDataLength; ++a)
        //                {
        //                    data[a] = allData[a + (allData.Length - remainDataLength)];
        //                }
        //                DismantleDataWithHead(data);
        //            }
        //            else //本次接不完
        //            {
        //                MemCpy(receiveDataAL, allData, receiveDataLength);
        //                receiveDataLength += allData.Length;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.Log(e);
        //    }
        //}
        //void DismantleDataWithoutHead(byte[] allData)
        //{
        //    try
        //    {
        //        if (receiveDataLength + allData.Length == allDataLengh)//本次刚好接完
        //        {
        //            // receiveDataAL.Add(allData);
        //            MemCpy(receiveDataAL, allData, receiveDataLength);
        //            receiveDataLength += allData.Length;
        //            ReceiveMessageOver();
        //        }
        //        else if (receiveDataLength + allData.Length > allDataLengh)///本次接完还有别的数据
        //        {
        //            int getDataLength = allDataLengh - receiveDataLength;//接收的数据
        //            byte[] data = new byte[getDataLength];

        //            for (int a = 0; a < getDataLength; ++a)
        //            {
        //                data[a] = allData[a];
        //            }
        //            //receiveDataAL.Add(data); 
        //            MemCpy(receiveDataAL, data, receiveDataLength);
        //            receiveDataLength += data.Length;
        //            ReceiveMessageOver();


        //            data = new byte[allData.Length - getDataLength];//剩余数据
        //            for (int a = 0; a < allData.Length - getDataLength; ++a)
        //            {
        //                data[a] = allData[a + getDataLength];
        //            }
        //            DismantleDataWithHead(data);
        //        }
        //        else//仍然没接完
        //        {
        //            // receiveDataAL.Add(allData);
        //            MemCpy(receiveDataAL, allData, receiveDataLength);
        //            receiveDataLength += allData.Length;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.Log(e);
        //    }

        //}

        //void ReceiveMessageOver()
        //{
        //    if (receiveDataAL.Length == 0)
        //        return;
        //    countTmp++;
        //    // Debug.Log("获得消息:" + receiveString);
        //    if (callBack_Receive != null)//回调
        //    {
        //        sEvent_NetMessageData messageData = new sEvent_NetMessageData();
        //        //callBack_Receive(this, true, error_Socket, "", Stars.Encryption.NetMsgDecryp(receiveDataAL), null);
        //        callBack_Receive(this, true, error_Socket, "", messageData, null);
        //    }
        //    receiveDataLength = 0;
        //    receiveDataAL = null;
        //    allDataLengh = 0;
        //}

        /// <summary>
        /// 超时检测,一般不会在这里停留，除了在editor中的Unity3d有bug
        /// </summary>
        /// <param name="ar"></param>
        /// <returns></returns>
        internal bool writeDot(IAsyncResult ar)
        {
            int i = 0;
            while (ar.IsCompleted == false)
            {
                if (i++ > 200)
                {
                    Debug.Log("Timed out.");
                    error_Socket = Erro_Socket.TIMEOUT;
                    return false;
                }
                Thread.Sleep(100);
            }
            return true;
        }

        public void reConnect(CallBack_Connect callBack_ReConnect)
        {
            _callBack_ReConnect = callBack_ReConnect;
            Async_ReConnect(CallBack_MyReConnect);
        }


        void CallBack_MyReConnect(bool success, Erro_Socket error, string exception)
        {
            if (_callBack_ReConnect != null)
            {
                _callBack_ReConnect(success, error, exception);
            }
        }

        public void reConnectCallback()
        {
            Async_ReConnect(CallBack_MyReConnect);
        }

        public void Async_ReConnect(CallBack_Connect callback_Connect)
        {
            removeConnectTask();
            connectTask_ = new ConnectTask(this._id, this.addressIP, this.port, callback_Connect);
            TaskManager taskMgr = Game.Get().findObject<TaskManager>();
            if (taskMgr != null)
            {
                taskMgr.addTask(connectTask_);
            }
        }

        public void reset()
        {
            if (clientSocket != null)
            {
                try
                {
                    if (clientSocket.Connected)
                        clientSocket.Disconnect(false);
                }
                catch
                {
                    Debug.LogError("DisConnect Fail,Maybe in Disconnecting");
                }
            }
            callBack_OnDisconnect = null;
            error_Socket = 0;
            receiveDataLength = 0;//当前接收长度
            allDataLengh = 0; //这类数据总长度
            receiveDataAL = null;//数据拼接用
            //sendCache.Clear();
            isReceiveHalfHead = false;
            iAsync_ReConnect = 0;
        }

        //public void clearSendCache()
        //{
        //    //sendCache.Clear();
        //}

        class StateObject
        {
            internal byte[] sBuffer;
            internal Socket sSocket;
            internal StateObject(int size, Socket sock)
            {
                sBuffer = new byte[size];
                sSocket = sock;
            }
            internal void setSocket(Socket sock)
            {
                sSocket = sock;
            }

            internal void resetBuffer()
            {
                Array.Clear(sBuffer, 0, sBuffer.Length);
            }
        }
    }
}