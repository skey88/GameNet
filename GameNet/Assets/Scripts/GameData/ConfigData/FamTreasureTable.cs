using System;
[Serializable]
public class FamTreasureTable :IConfig{
   private uint _id;
   private uint _name;
   private string _treasurePath;
   public FamTreasureTable (uint type_id,uint type_name,string type_treasurePath){
     _id =  (uint)type_id;
     _name =  type_name;
     _treasurePath =  type_treasurePath;
   }
  /// <summary>宝箱ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>名称</summary>
  public uint name{ get { return _name; }}
  /// <summary>宝箱预制件路径</summary>
  public string treasurePath{ get { return _treasurePath; }}
}
