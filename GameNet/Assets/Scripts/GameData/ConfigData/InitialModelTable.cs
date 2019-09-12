using System;
[Serializable]
public class InitialModelTable :IConfig{
   private uint _id;
   private string _skin;
   private string _hair;
   public InitialModelTable (uint type_id,string type_skin,string type_hair){
     _id =  (uint)type_id;
     _skin =  type_skin;
     _hair =  type_hair;
   }
  /// <summary>角色ID 1：女性角色 2：男性角色 3：教练</summary>
  public uint id{ get { return _id; }}
  /// <summary>骨骼</summary>
  public string skin{ get { return _skin; }}
  /// <summary>头发模型</summary>
  public string hair{ get { return _hair; }}
}
