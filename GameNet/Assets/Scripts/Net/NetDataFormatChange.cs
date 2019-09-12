using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Runtime.Serialization;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using com.sporger.server.proto.model;

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]

public class NetDataFormatChange
{
    /**/
    /// <summary>
    /// 结构体转byte数组
    /// </summary>
    /// <param name="structObj">要转换的结构体</param>
    /// <returns>转换后的byte数组</returns>
    public static byte[] StructToBytes(object structObj)
    {
        int size = Marshal.SizeOf(structObj);
        IntPtr buffer = Marshal.AllocHGlobal(size);
        try
        {
            Marshal.StructureToPtr(structObj, buffer, false);
            byte[] bytes = new byte[size];
            Marshal.Copy(buffer, bytes, 0, size);
            return bytes;
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    /**/
    /// <summary>
    /// byte数组转结构体
    /// </summary>
    /// <param name="bytes">byte数组</param>
    /// <param name="type">结构体类型</param>
    /// <returns>转换后的结构体</returns>
    public static object BytesToStruct(byte[] bytes, Type strcutType)
    {
        int size = Marshal.SizeOf(strcutType);
        IntPtr buffer = Marshal.AllocHGlobal(size);
        try
        {
            Marshal.Copy(bytes, 0, buffer, size);
            return Marshal.PtrToStructure(buffer, strcutType);
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    
    public static object CreateGeneric(Type generic, Type innerType, params object[] args)
    {
        Type specificType = generic.MakeGenericType(new System.Type[] { innerType });
        return Activator.CreateInstance(specificType, args);
    }

    public static int GetHeaderLength(object o)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream();
        formatter.Serialize(stream, o);
        return (int)stream.Length;
    }
    

    /// <summary>
    /// 返回data1和data2合拼的byte[]
    /// </summary>
    /// <param name="data1"></param>
    /// <param name="data2"></param>
    /// <returns></returns>
    public static byte[] ConnectBytes(byte[] data1, byte[] data2)
    {
        byte[] nCon = null;
        if (data2 == null)
        {
            nCon = new byte[data1.Length];
            data1.CopyTo(nCon, 0);
        }
        else
        {
            nCon = new byte[data1.Length + data2.Length];
            data1.CopyTo(nCon, 0);
            data2.CopyTo(nCon, data1.Length);
        }
        return nCon;

    }
    

    /// <summary>
    /// int 转byte数组+
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static byte[] intToByte(int i)
    {
        byte[] bt = System.BitConverter.GetBytes(i);
        return bt;
    }

    /// <summary>
    /// UInt16 转byte数组+
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static byte[] uInt16ToByte(UInt16 i)
    {
        byte[] bt = System.BitConverter.GetBytes(i);
        return bt;
    }

    /// <summary>
    /// byte数组转int
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static int byteToInt(byte[] b)
    {
        int n = System.BitConverter.ToInt32(b, 0);
        return n;
    }

    /// <summary>
    /// byte数组转Uint16
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static ushort byteToUInt16(byte[] b)
    {
        ushort n = System.BitConverter.ToUInt16(b, 0);
        return n;
    }

    /// <summary>
    /// float 转byte数组+
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static byte[] floatToByte(float i)
    {
        byte[] bt = System.BitConverter.GetBytes(i);
        return bt;
    }

    /// <summary>
    /// byte数组转float
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float byteTofloat(byte[] b)
    {
        float n = System.BitConverter.ToSingle(b, 0);
        return n;
    }
    /// <summary>
    /// Uint64转byte数组
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static byte[] uint64ToByte(ulong ul)
    {
        byte[] bt = System.BitConverter.GetBytes(ul);
        return bt;
    }
    /// <summary>
    /// byte数组转Uint64
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>	
    public static ulong byteToUint64(byte[] b)
    {
        ulong n = System.BitConverter.ToUInt64(b, 0);
        return n;
    }
    /// <summary>
    /// byte数组转Uint64
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>	
    public static string ASCIIByteArrayToString(byte[] characters)
    {
        ASCIIEncoding encoding = new ASCIIEncoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }
    public static string utf8FixedLengthByteArrayToString(byte[] characters)
    {
        List<byte> lbyte = new List<byte>();
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != 0)
            {
                lbyte.Add(characters[i]);
            }
            else
            {
                break;
            }
        }
        return utf8ByteListToString(lbyte);
    }
    public static string utf8ByteArrayToString(byte[] characters)
    {
		UTF8Encoding encoding = new UTF8Encoding();
		string constructedString = encoding.GetString(characters);
		return (constructedString);
    }

    public static string ASCIIByteListToString(List<byte> characters)
    {
        return ASCIIByteArrayToString(characters.ToArray());
    }

    public static string utf8ByteListToString(List<byte> characters)
    {
        return utf8ByteArrayToString(characters.ToArray());
    }

    public static byte[] stringToASCIIByteArray(string str)
    {
        byte[] bt = System.Text.Encoding.ASCII.GetBytes(str);
        return bt;
    }

    public static List<byte> stringToASCIIByteList(string str)
    {
        byte[] bt = System.Text.Encoding.ASCII.GetBytes(str);
        return bt.ToList<byte>();
    }

    public static byte[] stringToUtf8ByteArray(string str)
    {
        byte[] bt = System.Text.Encoding.UTF8.GetBytes(str);
        return bt;
    }

    public static List<byte> stringToUtf8ByteList(string str)
    {
        byte[] bt = System.Text.Encoding.UTF8.GetBytes(str);
        return bt.ToList<byte>();
    }

    public static float mSecondToSecondConverter(float @float)
    {
        return @float/1000;
    }

    /// <summary>
    /// 更换消息包的序号
    /// </summary>
    /// <param name="buff"></param>
    public static void modifySeq(byte[] buff, ulong seq)
    {
        byte[] seqArray = uint64ToByte(seq);
        int start = sizeof(uint) + sizeof(ushort);//PackHead.lenth+PackHead.cmd
        for (int i = 0; i < seqArray.Length; i++)
        {
            buff[start + i] = seqArray[i];
        }
    }

    /// <summary>
    /// 网络结构转数据
    /// </summary>
    /// <param name="tmpSocketData"></param>
    /// <returns></returns>
    public static byte[] SocketDataToBytes(sSocketData tmpSocketData)
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
    /// 数据转网络结构
    /// </summary>
    /// <param name="_protocalType"></param>
    /// <param name="_data"></param>
    /// <returns></returns>
    public static sSocketData BytesToSocketData(MessageType _protocalType, byte[] _data,string userId,ulong seq)
    {
        sSocketData tmpSocketData = new sSocketData();
        tmpSocketData._buffLength = Constants.HEAD_LEN_SEND + _data.Length;
        tmpSocketData._dataLength = _data.Length;
        tmpSocketData._protocallType = _protocalType;
        tmpSocketData._userid = userId;
        tmpSocketData._msgIndex = seq;
        tmpSocketData._data = _data;
        return tmpSocketData;
    }
}
