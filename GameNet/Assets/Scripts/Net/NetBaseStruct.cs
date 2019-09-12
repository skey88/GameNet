using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//包头前3项
[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct PackHead
{
    public uint lenth;
    public ushort cmd;
    public UInt64 seq;
    //[MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.HEAD_USERID_LEN)]
    //public byte[] userId; //36
}
