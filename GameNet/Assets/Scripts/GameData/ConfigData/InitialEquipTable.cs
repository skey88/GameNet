using System;
[Serializable]
public class InitialEquipTable :IConfig{
   private uint _id;
   private int _Jacket;
   private int _Trousers;
   private int _shoes;
   private int _Hat;
   public InitialEquipTable (uint type_id,int type_Jacket,int type_Trousers,int type_shoes,int type_Hat){
     _id =  (uint)type_id;
     _Jacket =  type_Jacket;
     _Trousers =  type_Trousers;
     _shoes =  type_shoes;
     _Hat =  type_Hat;
   }
  /// <summary>角色ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>上衣</summary>
  public int Jacket{ get { return _Jacket; }}
  /// <summary>裤子</summary>
  public int Trousers{ get { return _Trousers; }}
  /// <summary>鞋子</summary>
  public int shoes{ get { return _shoes; }}
  /// <summary>帽子</summary>
  public int Hat{ get { return _Hat; }}
}
