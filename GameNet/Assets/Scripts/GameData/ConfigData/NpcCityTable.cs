using System;
[Serializable]
public class NpcCityTable :IConfig{
   private uint _id;
   private uint _cityName;
   private uint _nationId;
   public NpcCityTable (uint type_id,uint type_cityName,uint type_nationId){
     _id =  (uint)type_id;
     _cityName =  type_cityName;
     _nationId =  type_nationId;
   }
  /// <summary>id</summary>
  public uint id{ get { return _id; }}
  /// <summary>城市名称  zhcn对应中文id</summary>
  public uint cityName{ get { return _cityName; }}
  /// <summary>所属国家  国家id</summary>
  public uint nationId{ get { return _nationId; }}
}
