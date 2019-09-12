using System;
[Serializable]
public class SquareSceneTable :IConfig{
   private uint _id;
   private string _scenename;
   private string _mapPath;
   private string _boundary;
   public SquareSceneTable (uint type_id,string type_scenename,string type_mapPath,string type_boundary){
     _id =  (uint)type_id;
     _scenename =  type_scenename;
     _mapPath =  type_mapPath;
     _boundary =  type_boundary;
   }
  /// <summary>竞速赛场景ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>场景名称</summary>
  public string scenename{ get { return _scenename; }}
  /// <summary>场景路径</summary>
  public string mapPath{ get { return _mapPath; }}
  /// <summary>关卡对应预制件路径 该预制件用来让策划配置路径等信息</summary>
  public string boundary{ get { return _boundary; }}
}
