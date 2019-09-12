using System;
[Serializable]
public class RaceMatchTable :IConfig{
   private uint _id;
   private int _equipType;
   private uint _describe;
   public RaceMatchTable (uint type_id,int type_equipType,uint type_describe){
     _id =  (uint)type_id;
     _equipType =  type_equipType;
     _describe =  type_describe;
   }
  /// <summary>竞速赛指数分段</summary>
  public uint id{ get { return _id; }}
  /// <summary>速度指数</summary>
  public int equipType{ get { return _equipType; }}
  /// <summary>匹配描述 描述会匹配哪些水平的其他玩家</summary>
  public uint describe{ get { return _describe; }}
}
