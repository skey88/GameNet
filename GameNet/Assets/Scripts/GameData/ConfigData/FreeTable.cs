using System;
[Serializable]
public class FreeTable :IConfig{
   private uint _id;
   private uint _freeName;
   private int _openLevel;
   private string _mapPath;
   private string _prefabsPath;
   private string _iconPath;
   private uint _sportStartCountdown;
   private uint _warmupStartCountdown;
   public FreeTable (uint type_id,uint type_freeName,int type_openLevel,string type_mapPath,string type_prefabsPath,string type_iconPath,uint type_sportStartCountdown,uint type_warmupStartCountdown){
     _id =  (uint)type_id;
     _freeName =  type_freeName;
     _openLevel =  type_openLevel;
     _mapPath =  type_mapPath;
     _prefabsPath =  type_prefabsPath;
     _iconPath =  type_iconPath;
     _sportStartCountdown =  type_sportStartCountdown;
     _warmupStartCountdown =  type_warmupStartCountdown;
   }
  /// <summary>自由跑id 0100000000生涯 0200000000自由 0300000000竞速 0400000000寻宝</summary>
  public uint id{ get { return _id; }}
  /// <summary>自由跑场景名 对应zhCN表中对应id的字符串</summary>
  public uint freeName{ get { return _freeName; }}
  /// <summary>开启等级</summary>
  public int openLevel{ get { return _openLevel; }}
  /// <summary>场景路径</summary>
  public string mapPath{ get { return _mapPath; }}
  /// <summary>关卡对应预制件路径 该预制件用来让策划配置路径等信息</summary>
  public string prefabsPath{ get { return _prefabsPath; }}
  /// <summary>地图icon路径</summary>
  public string iconPath{ get { return _iconPath; }}
  /// <summary>运动开始倒计时</summary>
  public uint sportStartCountdown{ get { return _sportStartCountdown; }}
  /// <summary>热身开始倒计时</summary>
  public uint warmupStartCountdown{ get { return _warmupStartCountdown; }}
}
