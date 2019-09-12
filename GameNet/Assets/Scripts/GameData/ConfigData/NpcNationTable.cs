using System;
[Serializable]
public class NpcNationTable :IConfig{
   private uint _id;
   private uint _nationId;
   private string _nationIconId;
   public NpcNationTable (uint type_id,uint type_nationId,string type_nationIconId){
     _id =  (uint)type_id;
     _nationId =  type_nationId;
     _nationIconId =  type_nationIconId;
   }
  /// <summary>id</summary>
  public uint id{ get { return _id; }}
  /// <summary>国家名称  填写zhcn表id</summary>
  public uint nationId{ get { return _nationId; }}
  /// <summary>所属国家图标 手动填写</summary>
  public string nationIconId{ get { return _nationIconId; }}
}
