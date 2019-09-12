using System;
[Serializable]
public class FamTreasurePointTable :IConfig{
   private uint _id;
   private string _pointx;
   private string _pointy;
   private string _pointz;
   private string _scene;
   private uint _sceneid;
   private uint _description;
   public FamTreasurePointTable (uint type_id,string type_pointx,string type_pointy,string type_pointz,string type_scene,uint type_sceneid,uint type_description){
     _id =  (uint)type_id;
     _pointx =  type_pointx;
     _pointy =  type_pointy;
     _pointz =  type_pointz;
     _scene =  type_scene;
     _sceneid =  type_sceneid;
     _description =  type_description;
   }
  /// <summary>1开头id表示单人普通（10001-11999）多人普通（12001-12999）；2表示道具点；3表示藏宝图宝箱点；4表示线索宝箱点；</summary>
  public uint id{ get { return _id; }}
  /// <summary>X坐标</summary>
  public string pointx{ get { return _pointx; }}
  /// <summary>Y坐标</summary>
  public string pointy{ get { return _pointy; }}
  /// <summary>z坐标</summary>
  public string pointz{ get { return _pointz; }}
  /// <summary>所在场景</summary>
  public string scene{ get { return _scene; }}
  /// <summary>所在场景ID</summary>
  public uint sceneid{ get { return _sceneid; }}
  /// <summary>位置描述ID，0表示没有描述</summary>
  public uint description{ get { return _description; }}
}
