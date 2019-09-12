using System;
[Serializable]
public class ItemTable :IConfig{
   private uint _id;
   private int _itemType;
   public ItemTable (uint type_id,int type_itemType){
     _id =  (uint)type_id;
     _itemType =  type_itemType;
   }
  /// <summary>道具id 100000女装备 200000男装备300000道具</summary>
  public uint id{ get { return _id; }}
  /// <summary>道具类型 0  装备 1  道具9货币</summary>
  public int itemType{ get { return _itemType; }}
}
