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
    public class SendMsgInfo
    {
        public byte[] _sendBuff;
        public float _sendTime;
        /// <summary>
        /// 是否已经发送
        /// </summary>
        //public bool _isSend = false;
        public SendMsgInfo(byte[] sendBuff, float sendTime)
        {
            _sendBuff = sendBuff;
            _sendTime = sendTime;
        }

        public ulong getindex()
        {
            PackHead packHead = (PackHead)NetDataFormatChange.BytesToStruct((byte[])_sendBuff, typeof(PackHead));
            return packHead.seq;
        }
    }
}