using System;
[Serializable]
public class FamPickupTable :IConfig{
   private uint _id;
   private uint _type;
   private int _distance;
   public FamPickupTable (uint type_id,uint type_type,int type_distance){
     _id =  (uint)type_id;
     _type =  type_type;
     _distance =  type_distance;
   }
  /// <summary>编号ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>拾取类型:1普通宝箱；2道具；3藏宝图宝箱；4线索宝箱；多人宝箱坑位</summary>
  public uint type{ get { return _type; }}
  /// <summary>拾取半径距离</summary>
  public int distance{ get { return _distance; }}
}
