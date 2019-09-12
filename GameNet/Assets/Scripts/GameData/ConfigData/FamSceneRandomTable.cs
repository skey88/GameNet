using System;
[Serializable]
public class FamSceneRandomTable :IConfig{
   private uint _id;
   private string _direction;
   private string _mapPath;
   private int _xlength;
   private int _ylength;
   private int _zlength;
   private uint _type;
   private string _minimap;
   public FamSceneRandomTable (uint type_id,string type_direction,string type_mapPath,int type_xlength,int type_ylength,int type_zlength,uint type_type,string type_minimap){
     _id =  (uint)type_id;
     _direction =  type_direction;
     _mapPath =  type_mapPath;
     _xlength =  type_xlength;
     _ylength =  type_ylength;
     _zlength =  type_zlength;
     _type =  type_type;
     _minimap =  type_minimap;
   }
  /// <summary>寻宝场景点位ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>子场景显示方向</summary>
  public string direction{ get { return _direction; }}
  /// <summary>场景点位</summary>
  public string mapPath{ get { return _mapPath; }}
  /// <summary>场景X轴长度</summary>
  public int xlength{ get { return _xlength; }}
  /// <summary>场景Y轴长度</summary>
  public int ylength{ get { return _ylength; }}
  /// <summary>场景Z轴长度</summary>
  public int zlength{ get { return _zlength; }}
  /// <summary>格子类型:1一个基本格子，2两个基本格子，3三个基本格子，4四个基本格子</summary>
  public uint type{ get { return _type; }}
  /// <summary>小地图素材</summary>
  public string minimap{ get { return _minimap; }}
}
