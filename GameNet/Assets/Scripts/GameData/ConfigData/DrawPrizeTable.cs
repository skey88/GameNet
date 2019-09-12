using System;
[Serializable]
public class DrawPrizeTable :IConfig{
   private uint _id;
   private uint _Id;
   private string _Icon;
   private uint _NameID;
   private uint _Type;
   private int _Drawtype;
   private int _Time;
   private int _Number;
   private int _Price;
   private int _Reward;
   public DrawPrizeTable (uint type_Id,string type_Icon,uint type_NameID,uint type_Type,int type_Drawtype,int type_Time,int type_Number,int type_Price,int type_Reward){
     _id =  (uint)type_Id;
     _Id =  type_Id;
     _Icon =  type_Icon;
     _NameID =  type_NameID;
     _Type =  type_Type;
     _Drawtype =  type_Drawtype;
     _Time =  type_Time;
     _Number =  type_Number;
     _Price =  type_Price;
     _Reward =  type_Reward;
   }
  /// <summary>抽奖ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>抽奖ID</summary>
  public uint Id{ get { return _Id; }}
  /// <summary>抽奖图标</summary>
  public string Icon{ get { return _Icon; }}
  /// <summary>抽奖名称ID</summary>
  public uint NameID{ get { return _NameID; }}
  /// <summary>星级类型</summary>
  public uint Type{ get { return _Type; }}
  /// <summary>抽奖类型1：金币抽奖2：钻石抽奖</summary>
  public int Drawtype{ get { return _Drawtype; }}
  /// <summary>CD时间</summary>
  public int Time{ get { return _Time; }}
  /// <summary>免费次数</summary>
  public int Number{ get { return _Number; }}
  /// <summary></summary>
  public int Price{ get { return _Price; }}
  /// <summary>掉落包</summary>
  public int Reward{ get { return _Reward; }}
}
