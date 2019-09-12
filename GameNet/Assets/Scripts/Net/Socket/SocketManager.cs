using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System;
using System.Text;
using System.IO;
using ProtoBuf;
using com.sporger.server.proto.model;
using Stars;

public class SocketManager
{
    static ulong _msgid = 1;
    private static SocketManager _instance;
    public static SocketManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SocketManager();
            }
            return _instance;
        }
    }

    public static bool HaveInstance()
    {
        return _instance != null;
    }

    private string _currIP;
    private int _currPort;

    private bool _isConnected = false;
    public bool IsConnceted { get { return _isConnected; } }
    private Socket clientSocket = null;
    private Thread receiveThread = null;

    private DataBuffer _databuffer = new DataBuffer();

    byte[] _tmpReceiveBuff = new byte[8192];
    private sSocketData _socketData = new sSocketData();
    private string _userID = "5105ab7f-0747-45a3-951f-ccdbac5b6c07";//不能在这里设置，改到LocalPlayerModel
    /// <summary>
    /// 断开
    /// </summary>
    private void _close()
    {
        if (!_isConnected)
            return;

        _isConnected = false;

        if (receiveThread != null)
        {
            receiveThread.Abort();
            receiveThread = null;
        }

        if (clientSocket != null && clientSocket.Connected)
        {
            clientSocket.Close();
            clientSocket = null;
        }
    }

    private void _ReConnect()
    {
    }

    /// <summary>
    /// 连接
    /// </summary>
    private void _onConnet()
    {
        try
        {
            //IPAddress[] address = Dns.GetHostAddresses("test.thisisgame.com.cn");

            //IPAddress[] address = Dns.GetHostAddresses(_currIP);

            //foreach (var info in address)
            //{
            //    Debug.Log(info);
            //}

            //if (address[0].AddressFamily == AddressFamily.InterNetworkV6)
            //{
            //    Debug.Log("Connect InterNetworkV6");
            //    clientSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            //}
            //else
            //{
            //    Debug.Log("Connect InterNetwork");
            //    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //}


            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建套接字
            IPAddress ipAddress = IPAddress.Parse(_currIP);//解析IP地址
            IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, _currPort);
            IAsyncResult result = clientSocket.BeginConnect(ipEndpoint, new AsyncCallback(_onConnect_Sucess), clientSocket);//异步连接
            bool success = result.AsyncWaitHandle.WaitOne(5000, true);
            if (!success) //超时
            {
                _onConnect_Outtime();
            }
        }
        catch (System.Exception _e)
        {
            Debug.Log(_e.Message);
            _onConnect_Fail();
        }
    }

    private void _onConnect_Sucess(IAsyncResult iar)
    {
        try
        {
            Socket client = (Socket)iar.AsyncState;
            client.EndConnect(iar);

            receiveThread = new Thread(new ThreadStart(_onReceiveSocket));
            receiveThread.IsBackground = true;
            receiveThread.Start();
            _isConnected = true;
            //if (_callback != null)
            //{
            //    _callback(true);
            //}
            Debug.Log("连接成功,"+ _currIP+":"+ _currPort);
        }
        catch (Exception _e)
        {
            Debug.Log(_e.Message);
            Close();
            //if(_callback != null)
            //{
            //    _callback(false);
            //}
        }
    }


    private void _onConnect_Outtime()
    {
        _close();
    }

    private void _onConnect_Fail()
    {
        _close();
    }

    /// <summary>
    /// 发送消息结果回掉，可判断当前网络状态
    /// </summary>
    /// <param name="asyncSend"></param>
    private void _onSendMsg(IAsyncResult asyncSend)
    {
        try
        {
            Socket client = (Socket)asyncSend.AsyncState;
            client.EndSend(asyncSend);
        }
        catch (Exception e)
        {
            Debug.Log("send msg exception:" + e.StackTrace);
        }
    }

    /// <summary>
    /// 接受网络数据
    /// </summary>
    private void _onReceiveSocket()
    {
        while (true)
        {
            if (!clientSocket.Connected)
            {
                _isConnected = false;
                _ReConnect();
                break;
            }
            try
            {
                int receiveLength = clientSocket.Receive(_tmpReceiveBuff);
                if (receiveLength > 0)
                {
                    _databuffer.AddBuffer(_tmpReceiveBuff, receiveLength);//将收到的数据添加到缓存器中
                    while (_databuffer.GetData(out _socketData))//取出一条完整数据
                    {
                        sEvent_NetMessageData tmpNetMessageData = new sEvent_NetMessageData();
                        tmpNetMessageData._eventType = _socketData._protocallType;
                        tmpNetMessageData._msgIndex = _socketData._msgIndex;
                        tmpNetMessageData._errorcode = _socketData._errorCode;
                        tmpNetMessageData._eventData = _socketData._data;

                        //锁死消息中心消息队列，并添加数据
                        lock (MessageCenter.Instance._netMessageDataQueue)
                        {
                            //Debug.Log("receive msg = " + tmpNetMessageData._eventType + " " + tmpNetMessageData._msgIndex + " " + tmpNetMessageData._errorcode);
                            MessageCenter.Instance._netMessageDataQueue.Enqueue(tmpNetMessageData);
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
                clientSocket.Disconnect(true);
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                break;
            }
        }
    }

    /// <summary>
    /// 数据转网络结构
    /// </summary>
    /// <param name="_protocalType"></param>
    /// <param name="_data"></param>
    /// <returns></returns>
    private sSocketData BytesToSocketData(MessageType _protocalType, byte[] _data)
    {
        sSocketData tmpSocketData = new sSocketData();
        tmpSocketData._buffLength = Constants.HEAD_LEN_SEND + _data.Length;
        tmpSocketData._dataLength = _data.Length;
        tmpSocketData._protocallType = _protocalType;
        tmpSocketData._userid = _userID;
        tmpSocketData._msgIndex = GetMsgID();
        tmpSocketData._data = _data;
        return tmpSocketData;
    }

    ulong GetMsgID()
    {
        return _msgid++;
    }
    /// <summary>
    /// 网络结构转数据
    /// </summary>
    /// <param name="tmpSocketData"></param>
    /// <returns></returns>
    private byte[] SocketDataToBytes(sSocketData tmpSocketData)
    {
        byte[] _tmpBuff = new byte[tmpSocketData._buffLength];
        byte[] _tmpBuffLength = BitConverter.GetBytes(tmpSocketData._buffLength);
        byte[] _tmpProtocallType = BitConverter.GetBytes((UInt16)tmpSocketData._protocallType);
        byte[] _temMsgIdx = BitConverter.GetBytes(tmpSocketData._msgIndex);
        byte[] _temUserId = Encoding.ASCII.GetBytes(tmpSocketData._userid);

        Array.Copy(_tmpBuffLength, 0, _tmpBuff, 0, Constants.HEAD_DATA_LEN);//缓存总长度
        Array.Copy(_tmpProtocallType, 0, _tmpBuff, Constants.HEAD_DATA_LEN, Constants.HEAD_TYPE_LEN);//协议类型
        Array.Copy(_temMsgIdx, 0, _tmpBuff, Constants.HEAD_DATA_LEN + Constants.HEAD_TYPE_LEN, Constants.HEAD_INDEX_LEN);//消息序号
        Array.Copy(_temUserId, 0, _tmpBuff, Constants.HEAD_DATA_LEN + Constants.HEAD_TYPE_LEN + Constants.HEAD_INDEX_LEN, Constants.HEAD_USERID_LEN);//用户ID

        Array.Copy(tmpSocketData._data, 0, _tmpBuff, Constants.HEAD_LEN_SEND, tmpSocketData._dataLength);//协议数据

        return _tmpBuff;
    }

    /// <summary>
    /// 合并协议，数据
    /// </summary>
    /// <param name="_protocalType"></param>
    /// <param name="_data"></param>
    /// <returns></returns>
    private byte[] DataToBytes(MessageType _protocalType, byte[] _data)
    {
        return SocketDataToBytes(BytesToSocketData(_protocalType, _data));
    }


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
            //T obj = Serializer.DeserializeWithLengthPrefix<T>(m, PrefixStyle.Base128);
            //return obj;
            return Serializer.Deserialize<T>(m);
        }
    }



    /// <summary>
    /// 连接服务器
    /// </summary>
    /// <param name="_currIP"></param>
    /// <param name="_currPort"></param>
    public void Connect(string _currIP, int _currPort)
    {
        if (!IsConnceted)
        {
            this._currIP = _currIP;
            this._currPort = _currPort;
            //this._callback = callback;
            _onConnet();
        }
    }

    /// <summary>
    /// 发送消息基本方法
    /// </summary>
    /// <param name="_protocalType"></param>
    /// <param name="_data"></param>
    private void SendMsgBase(MessageType _protocalType, byte[] _data)
    {
        if (clientSocket == null || !clientSocket.Connected)
        {
            _ReConnect();
            return;
        }

        byte[] _msgdata = DataToBytes(_protocalType, _data);
        clientSocket.BeginSend(_msgdata, 0, _msgdata.Length, SocketFlags.None, new AsyncCallback(_onSendMsg), clientSocket);

        //Debug.Log("已发送消息");
    }

    /// <summary>
    /// 以二进制方式发送
    /// </summary>
    /// <param name="_protocalType"></param>
    /// <param name="_byteStreamBuff"></param>
    public void SendMsg(MessageType _protocalType, ByteStreamBuff _byteStreamBuff)
    {
        SendMsgBase(_protocalType, _byteStreamBuff.ToArray());
    }

    /// <summary>
    /// 以ProtoBuf方式发送
    /// </summary>
    /// <param name="_protocalType"></param>
    /// <param name="data"></param>
    public void SendMsg(MessageType _protocalType, ProtoBuf.IExtensible data)
    {
        SendMsgBase(_protocalType, ProtoBuf_Serializer(data));
    }

    public void Close()
    {
        _close();
        Debug.Log("已关闭连接");
    }


    public void SetUserID(string id)
    {
        _userID = id;
    }

}