using System;
[Serializable]
public class MazePrefabTable :IConfig{
   private uint _id;
   private string _mazePath;
   public MazePrefabTable (uint type_id,string type_mazePath){
     _id =  (uint)type_id;
     _mazePath =  type_mazePath;
   }
  /// <summary>素材ID：1表示门的，2表示终点</summary>
  public uint id{ get { return _id; }}
  /// <summary>素材预制件路径</summary>
  public string mazePath{ get { return _mazePath; }}
}
