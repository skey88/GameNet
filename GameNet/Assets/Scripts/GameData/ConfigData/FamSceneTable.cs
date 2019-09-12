using System;
[Serializable]
public class FamSceneTable :IConfig{
   private uint _id;
   private string _sceneid;
   private string _scenename;
   private string _mapPath;
   private string _boundary;
   private int _xlength;
   private int _ylength;
   private int _zlength;
   private uint _name;
   private string _sceneicon;
   private uint _describe;
   private string _time;
   private uint _countdown;
   public FamSceneTable (uint type_id,string type_sceneid,string type_scenename,string type_mapPath,string type_boundary,int type_xlength,int type_ylength,int type_zlength,uint type_name,string type_sceneicon,uint type_describe,string type_time,uint type_countdown){
     _id =  (uint)type_id;
     _sceneid =  type_sceneid;
     _scenename =  type_scenename;
     _mapPath =  type_mapPath;
     _boundary =  type_boundary;
     _xlength =  type_xlength;
     _ylength =  type_ylength;
     _zlength =  type_zlength;
     _name =  type_name;
     _sceneicon =  type_sceneicon;
     _describe =  type_describe;
     _time =  type_time;
     _countdown =  type_countdown;
   }
  /// <summary>寻宝场景id</summary>
  public uint id{ get { return _id; }}
  /// <summary>场景点位id（支持多个场景点位）</summary>
  public string sceneid{ get { return _sceneid; }}
  /// <summary>场景名称</summary>
  public string scenename{ get { return _scenename; }}
  /// <summary>场景路径</summary>
  public string mapPath{ get { return _mapPath; }}
  /// <summary>场景边界路径</summary>
  public string boundary{ get { return _boundary; }}
  /// <summary>地图X轴大小</summary>
  public int xlength{ get { return _xlength; }}
  /// <summary>地图Y轴大小</summary>
  public int ylength{ get { return _ylength; }}
  /// <summary>地图Z轴大小</summary>
  public int zlength{ get { return _zlength; }}
  /// <summary>寻宝场景名称</summary>
  public uint name{ get { return _name; }}
  /// <summary>地图icon路径</summary>
  public string sceneicon{ get { return _sceneicon; }}
  /// <summary>寻宝场景描述</summary>
  public uint describe{ get { return _describe; }}
  /// <summary>寻宝活动时间</summary>
  public string time{ get { return _time; }}
  /// <summary>活动结束倒计时</summary>
  public uint countdown{ get { return _countdown; }}
}
