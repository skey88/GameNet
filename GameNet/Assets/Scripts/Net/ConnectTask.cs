using UnityEngine;
using System.Collections;
using System.Threading;
using System.Runtime.InteropServices;
using System;
using System.IO;
using System.Collections.Generic;
using com.sporger.server.proto.model;
using ProtoBuf;

namespace Stars
{
    public class ConnectTask : Task
    {
        ClientSocket.CallBack_Connect _callBack;
        int _id;
        string _ip;
        int _port;
        bool _readyReconnect = false;
        float _waitTime = 0;
        bool _isOver = false;

        bool _isSuccess = false;
        ClientSocket.Erro_Socket _error = ClientSocket.Erro_Socket.TIMEOUT;
        string _exception = "Time out";
        bool _isShowWaiting = false;
        public ConnectTask(int id, string ip, int port, ClientSocket.CallBack_Connect callback_connect)
        {
            _id = id;
            _ip = ip;
            _port = port;
            _callBack = callback_connect;
            Net.Get().connect(_id, _ip, _port, connectCallback);
        }

        public override bool update(float interval)
        {
            if (!_isShowWaiting)
            {
                //在第二帧显示，防止其它线程显示时出错
                try
                {
                    Net.Get().UIShowWaiting();
                }
                catch
                {
                    Debug.LogError("Net.getInstance().UIShowWaiting() fail");
                }

                _isShowWaiting = true;
            }
            if (_isOver)
            {
                if (_callBack != null)
                {
                    _callBack(_isSuccess, _error, _exception);
                    _callBack = null;
                }

                Net.Get().UIHideWaiting();
                _isShowWaiting = false;
                return false;
            }
            _waitTime += interval;
            if (_waitTime > Net.sendMsgTimeout_)
            {
                _isOver = true;
                Net.Get().disConnect(_id);
            }
            return true;
        }
        /// <summary>
        /// 连接回调
        /// </summary>
        /// <param name="skSocket"></param>
        /// <param name="success"></param>
        /// <param name="error"></param>
        /// <param name="exception"></param>
        void connectCallback(bool success, ClientSocket.Erro_Socket error, string exception)
        {
            _isSuccess = success;
            _error = error;
            _exception = exception;
            _isOver = true;
        }

        public override void disable()
        {
            base.disable();
            _callBack = null;
        }
    }
}