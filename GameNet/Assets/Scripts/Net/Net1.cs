using UnityEngine;
using System.Collections;
using System.Threading;
using System.Runtime.InteropServices;
using System;
using System.IO;
using System.Collections.Generic;
using com.sporger.server.proto.model;
using ProtoBuf;
using System.Text;
/// 非主要逻辑
namespace Stars
{
    //服务器编号
    public enum ServerNumber
    {
        Game,
    };

    public enum ClientNetStats
    {
        Valid,
        InValid
    }

    public partial class Net : SingletonNewFirst<Net>, IGameSubSystem
    {

        void sendHeartBeat()
        {
            if (isConnect())
            {
                sendMsg(MessageType.HEARTBEAT, null);
            }
        }

        void initHeartBeatTimer()
        {
            if (_sendHeartBeatTimer == null)
            {
                _sendHeartBeatTimer = TimerManager.Instance.GenerateTimer(SendHeartBeatTime);
                _sendHeartBeatTimer.tick = sendHeartBeat;
                _sendHeartBeatTimer.Isloop = true;
                _sendHeartBeatTimer.Run();
            }
        }

        void initPing()
        {
            if (pingTimer == null)
            {
                pingTimer = TimerManager.Instance.GenerateTimer(PingTime);
                pingTimer.tick = updatePingGameServer;
                pingTimer.Isloop = true;
                pingTimer.Run();
            }
        }

        /// <summary>
        /// 添加获取游戏服务器ping值监听
        /// </summary>
        /// <param name="listener"></param>
        public void addGetPingTimeListener(Action<float> listener)
        {
            notifyPingTime += listener;
        }
        /// <summary>
        /// 移除获取游戏服务器ping值监听
        /// </summary>
        /// <param name="listener"></param>
        public void removeGetPingTimeListerner(Action<float> listener)
        {
            notifyPingTime -= listener;
        }

        void updatePingGameServer()
        {
            //如果服务器连不上ping.isDone永远为flse
            if (ping == null || (ping != null && ping.isDone))
            {
                if (ping != null)
                {
                    lastPingTime = ping.time;
                    if (notifyPingTime != null)
                    {
                        notifyPingTime(lastPingTime);
                    }
                }
                ping = new Ping(gameServerIp);
                pingCountTime = 0;
            }
            else
            {
                pingCountTime += Time.deltaTime;
                if (pingCountTime > 5)
                {
                    lastPingTime = -1;
                }
            }
        }
        /// <summary>
        /// 返回ping值(ms),如果为-1，表示未连接服务器或连接不上服务器
        /// </summary>
        /// <returns></returns>
        float getPingTime()
        {
            return lastPingTime;
        }


        /// <summary>
        /// 增加发送消息超时回调
        /// </summary>
        /// <param name="server"></param>
        /// <param name="callback"></param>
        void addSendMsgTimeoutCallback(ServerNumber server, SendMsgTimeoutCallback callback)
        {
            if ((int)server < MaxConnectNum)
            {
                _sendMsgTimeoutCallback[(int)server] += callback;
            }
        }
        /// <summary>
        /// 移除发送消息超时回调
        /// </summary>
        /// <param name="server"></param>
        /// <param name="callback"></param>
        void removeSendMsgTimeoutCallback(ServerNumber server, SendMsgTimeoutCallback callback)
        {
            if ((int)server < MaxConnectNum)
            {
                _sendMsgTimeoutCallback[(int)server] -= callback;
            }
        }
        /// <summary>
        /// 增加发送消息超时用户确认后回调
        /// </summary>
        /// <param name="server"></param>
        /// <param name="callback"></param>
        void addSendMsgTimeoutConfirmCallback(ServerNumber server, SendMsgTimeoutConfirmCallback callback)
        {
            if ((int)server < MaxConnectNum)
            {
                _sendMsgTimeoutConfirmCallback[(int)server] += callback;
            }
        }
        /// <summary>
        /// 移除发送消息超时用户确认后回调
        /// </summary>
        /// <param name="server"></param>
        /// <param name="callback"></param>
        void removeSendMsgTimeoutConFirmCallback(ServerNumber server, SendMsgTimeoutConfirmCallback callback)
        {
            if ((int)server < MaxConnectNum)
            {
                _sendMsgTimeoutConfirmCallback[(int)server] -= callback;
            }
        }

        public void addReconnectSucCallback(ReConnectSeverSucCallBack callback)
        {
            _reConnectSeverSucCallBack += callback;
        }

        public void removeReconnectSucCallback(ReConnectSeverSucCallBack callback)
        {
            _reConnectSeverSucCallBack -= callback;
        }
        public void UIShowWaiting(string info = "", float showTipTime = 2)
        {
            //Game.Get().SendNotification(RGGameGlobalEventType.SHOW_NET_CONNECTION_TIPS);
            Debug.Log("SHOW_NET_CONNECTION_TIPS");
        }

        public void UIHideWaiting()
        {
            //Game.Get().SendNotification(RGGameGlobalEventType.HIDE_NET_CONNECTION_TIPS, null);
            Debug.Log("HIDE_NET_CONNECTION_TIPS");
        }

        public void UIWaitingForceHide()
        {
            UIHideWaiting();
        }


        public bool getServerConnected(int index)
        {
            if (index > MaxConnectNum - 1)
            {
                return false;
            }
            if (socketList_[index] != null && socketList_[index].IsConnect())
            {
                return true;
            }

            return false;
        }

        public void SetUserId(string id)
        {
            _userId = id;
        }

        public void close()
        {
            foreach (ClientSocket socket in socketList_)
            {
                if (socket != null)
                {
                    socket.Async_Disconnect(null);
                }
            }
            if(thread != null)
            {
                thread.Abort();
                thread = null;
            }
        }

        /// <summary>
        /// ProtoBuf反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_data"></param>
        /// <returns></returns>
        public static T ProtoBuf_Deserialize<T>(byte[] _data)
        {
            using (MemoryStream m = new MemoryStream(_data))
            {
                return Serializer.Deserialize<T>(m);
            }
        }

        public bool isConnect()
        {
            if (socketList_[(int)ServerNumber.Game] != null)
                return socketList_[(int)ServerNumber.Game].IsConnect();
            return false;
        }


        public void setSession(string session)
        {
            _session = session;
        }

        public string getSession()
        {
            return _session;
        }

        public void setLoginSuccess(bool isSucess)
        {
            _isLoginSucces = isSucess;
        }

        public void reset()
        {
            resetWhenBackToLogin();
        }

        public void resetWhenBackToLogin()
        {
            lock (send_MessageDataPoolAL)
            {
                send_MessageDataPoolAL.Clear();
            }

            lock (_netMessageDataQueue)
            {
                _netMessageDataQueue.Clear();
            }
            _sendBuffs.Clear();
            isUpdate_ = true;
            _relogin = false;
            _beginSendReloginMsg = 0;
            _isShowNetLostConn = false;
            _needReconnect = false;
            _reloginGameWaitUserConfirm = false;
            //重新连接的次数计数
            _reLoginGameCount = 0;
            //重连准备时间，如果大于退避时间就开始重连
            _reloginPrepareTime = 0;
            //用于统计指数退避时间的标记
            _reloginReady = false;
            if (socketList_[(int)ServerNumber.Game] != null)
            {
                socketList_[(int)ServerNumber.Game].reset();
            }
            _netStats = ClientNetStats.Valid;
        }

        bool isMsgNoResponse(ServerNumber serverId)
        {
            foreach (SendMsgInfo smi in _sendBuffs.Values)
            {
                PackHead packHead = (PackHead)NetDataFormatChange.BytesToStruct((byte[])smi._sendBuff, typeof(PackHead));
                int serverMsgToSend = getServerId(packHead.cmd);
                if (serverMsgToSend == (int)serverId)
                {
                    return true;
                }
            }
            return false;
        }

        //void ShowGloabalTip(MsgBoxPara mbp)
        //{
        //    if (Game.Get() != null)
        //    {
        //        Game.Get().SendNotification(RGGameGlobalEventType.SHOW_GLOBAL_TIP, mbp);
        //    }
        //}

        /// <summary>
        /// ProtoBuf序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ProtoBuf_Serializer(ProtoBuf.IExtensible data)
        {
            if (data == null) return new byte[0];
            using (MemoryStream m = new MemoryStream())
            {
                byte[] buffer = null;
                Serializer.Serialize(m, data);
                m.Position = 0;
                int length = (int)m.Length;
                buffer = new byte[length];
                m.Read(buffer, 0, length);
                return buffer;
            }
        }

        public void fixUpdate(float deltaTime)
        {
        }

        public void lateUpdate(float deltaTime)
        {
        }

        public void regEvent()
        {
        }

        public void removeEvent()
        {
        }

        public void shutdown()
        {
            close();
        }

        public void onPause()
        {
        }

        public void onResume()
        {
        }
    }

 
}