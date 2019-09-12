using System;
[Serializable]
public class RaceSceneTable :IConfig{
   private uint _id;
   private string _mapPath;
   private string _prefabsPath;
   private string _beginCinematics;
   public RaceSceneTable (uint type_id,string type_mapPath,string type_prefabsPath,string type_beginCinematics){
     _id =  (uint)type_id;
     _mapPath =  type_mapPath;
     _prefabsPath =  type_prefabsPath;
     _beginCinematics =  type_beginCinematics;
   }
  /// <summary>竞速赛场景ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>场景路径</summary>
  public string mapPath{ get { return _mapPath; }}
  /// <summary>关卡对应预制件路径 该预制件用来让策划配置路径等信息</summary>
  public string prefabsPath{ get { return _prefabsPath; }}
  /// <summary>开场镜头动画路径</summary>
  public string beginCinematics{ get { return _beginCinematics; }}
}
