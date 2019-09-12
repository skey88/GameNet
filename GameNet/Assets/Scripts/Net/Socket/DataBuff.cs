using System.IO;
using System;
using UnityEngine;
using com.sporger.server.proto.model;

//常量数据
public class Constants
{
    public const int HEAD_DATA_LEN = 4;
    public const int HEAD_TYPE_LEN = 2;
    public const int HEAD_INDEX_LEN = 8;
    public const int HEAD_ERRORCODE_LEN = 2;
    public const int HEAD_USERID_LEN = 36;

    public const int HEAD_LEN_RECIVE = HEAD_DATA_LEN + HEAD_TYPE_LEN + HEAD_INDEX_LEN + HEAD_ERRORCODE_LEN;
    public const int HEAD_LEN_SEND = HEAD_DATA_LEN + HEAD_TYPE_LEN + HEAD_INDEX_LEN + HEAD_USERID_LEN;
}

/// <summary>
/// 网络数据结构
/// </summary>
[System.Serializable]
public struct sSocketData
{
    public byte[] _data;
    public MessageType _protocallType;
    public ulong _msgIndex;
    public ushort _errorCode;
    public string _userid;
    public int _buffLength;
    public int _dataLength;
}

/// <summary>
/// 网络数据缓存器，
/// </summary>
[System.Serializable]
public class DataBuffer
{//自动大小数据缓存器
    private int _minBuffLen;
    private byte[] _buff;
    private int _curBuffPosition;
    private int _buffLength = 0;
    private int _dataLength;
    private UInt16 _protocalType;
    private UInt64 _msgIndex;
    private UInt16 _errorCode;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_minBuffLen">最小缓冲区大小</param>
    public DataBuffer(int _minBuffLen = 1024)
    {
        if (_minBuffLen <= 0)
        {
            this._minBuffLen = 1024;
        }
        else
        {
            this._minBuffLen = _minBuffLen;
        }
        _buff = new byte[this._minBuffLen];
    }

    /// <summary>
    /// 添加缓存数据
    /// </summary>
    /// <param name="_data"></param>
    /// <param name="_dataLen"></param>
    public void AddBuffer(byte[] _data, int _dataLen)
    {
        if (_dataLen > _buff.Length - _curBuffPosition)//超过当前缓存
        {
            byte[] _tmpBuff = new byte[_curBuffPosition + _dataLen];
            Array.Copy(_buff, 0, _tmpBuff, 0, _curBuffPosition);
            Array.Copy(_data, 0, _tmpBuff, _curBuffPosition, _dataLen);
            _buff = _tmpBuff;
            _tmpBuff = null;
        }
        else
        {
            Array.Copy(_data, 0, _buff, _curBuffPosition, _dataLen);
        }
        _curBuffPosition += _dataLen;//修改当前数据标记
    }

    /// <summary>
    /// 更新数据长度
    /// </summary>
    public void UpdateDataLength()
    {
        if (_dataLength == 0 && _curBuffPosition >= Constants.HEAD_LEN_RECIVE)
        {
            byte[] tmpDataLen = new byte[Constants.HEAD_DATA_LEN];
            Array.Copy(_buff, 0, tmpDataLen, 0, Constants.HEAD_DATA_LEN);
            //与java服务器交互，需要反转
            Array.Reverse(tmpDataLen);
            _buffLength = BitConverter.ToInt32(tmpDataLen, 0);

            byte[] tmpProtocalType = new byte[Constants.HEAD_TYPE_LEN];
            Array.Copy(_buff, Constants.HEAD_DATA_LEN, tmpProtocalType, 0, Constants.HEAD_TYPE_LEN);
            //与java服务器交互，需要反转
            //Array.Reverse(tmpProtocalType);
            _protocalType = BitConverter.ToUInt16(tmpProtocalType, 0);

            byte[] tmpMsgIdx = new byte[Constants.HEAD_INDEX_LEN];
            Array.Copy(_buff, Constants.HEAD_DATA_LEN + Constants.HEAD_TYPE_LEN, tmpMsgIdx, 0, Constants.HEAD_INDEX_LEN);

            //Array.Reverse(tmpMsgIdx);
            _msgIndex = BitConverter.ToUInt64(tmpMsgIdx, 0);

            byte[] tmpErrorCode = new byte[Constants.HEAD_ERRORCODE_LEN];
            Array.Copy(_buff, Constants.HEAD_DATA_LEN + Constants.HEAD_TYPE_LEN + Constants.HEAD_INDEX_LEN, tmpErrorCode, 0, Constants.HEAD_ERRORCODE_LEN);

            //Array.Reverse(tmpErrorCode);
            _errorCode = BitConverter.ToUInt16(tmpErrorCode, 0);

            _dataLength = _buffLength - Constants.HEAD_LEN_RECIVE;
        }
    }

    /// <summary>
    /// 获取一条可用数据，返回值标记是否有数据
    /// </summary>
    /// <param name="_tmpSocketData"></param>
    /// <returns></returns>
    public bool GetData(out sSocketData _tmpSocketData)
    {
        _tmpSocketData = new sSocketData();
        if (_buffLength <= 0)
        {
            UpdateDataLength();
        }

        if (_buffLength > 0 && _curBuffPosition >= _buffLength)
        {

            _tmpSocketData._buffLength = _buffLength;
            _tmpSocketData._dataLength = _dataLength;
            _tmpSocketData._protocallType = (MessageType)_protocalType;
            _tmpSocketData._msgIndex = _msgIndex;
            _tmpSocketData._errorCode = _errorCode;

            _tmpSocketData._data = new byte[_dataLength];
            Array.Copy(_buff, Constants.HEAD_LEN_RECIVE, _tmpSocketData._data, 0, _dataLength);
            _curBuffPosition -= _buffLength;
            byte[] _tmpBuff = new byte[_curBuffPosition < _minBuffLen ? _minBuffLen : _curBuffPosition];
            Array.Copy(_buff, _buffLength, _tmpBuff, 0, _curBuffPosition);
            _buff = _tmpBuff;


            _buffLength = 0;
            _dataLength = 0;
            _protocalType = 0;
            _msgIndex = 0;
            _errorCode = 0;
            return true;
        }
        return false;
    }
    
}