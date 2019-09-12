using System;
[Serializable]
public class MazePointTable :IConfig{
   private uint _id;
   private string _pointx;
   private string _pointy;
   private string _pointz;
   public MazePointTable (uint type_id,string type_pointx,string type_pointy,string type_pointz){
     _id =  (uint)type_id;
     _pointx =  type_pointx;
     _pointy =  type_pointy;
     _pointz =  type_pointz;
   }
  /// <summary>点坐标ID：1表示门的位置，2表示终点位置</summary>
  public uint id{ get { return _id; }}
  /// <summary>X坐标</summary>
  public string pointx{ get { return _pointx; }}
  /// <summary>Y坐标</summary>
  public string pointy{ get { return _pointy; }}
  /// <summary>z坐标</summary>
  public string pointz{ get { return _pointz; }}
}
