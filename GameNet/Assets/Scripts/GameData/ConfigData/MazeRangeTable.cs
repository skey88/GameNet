using System;
[Serializable]
public class MazeRangeTable :IConfig{
   private uint _id;
   private uint _type;
   private int _distance;
   public MazeRangeTable (uint type_id,uint type_type,int type_distance){
     _id =  (uint)type_id;
     _type =  type_type;
     _distance =  type_distance;
   }
  /// <summary>编号ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>类型:1门；2终点</summary>
  public uint type{ get { return _type; }}
  /// <summary>功能触发半径距离</summary>
  public int distance{ get { return _distance; }}
}
