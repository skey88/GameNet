using System;
[Serializable]
public class RaceTable :IConfig{
   private uint _id;
   private uint _beginCinematicsLenth;
   public RaceTable (uint type_id,uint type_beginCinematicsLenth){
     _id =  (uint)type_id;
     _beginCinematicsLenth =  type_beginCinematicsLenth;
   }
  /// <summary>竞速赛id </summary>
  public uint id{ get { return _id; }}
  /// <summary>开场镜头动画 时间（单位/秒）</summary>
  public uint beginCinematicsLenth{ get { return _beginCinematicsLenth; }}
}
