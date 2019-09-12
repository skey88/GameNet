using System;
[Serializable]
public class LeveGradeTable :IConfig{
   private uint _id;
   private uint _percent;
   private string _gradeName;
   public LeveGradeTable (uint type_id,uint type_percent,string type_gradeName){
     _id =  (uint)type_id;
     _percent =  type_percent;
     _gradeName =  type_gradeName;
   }
  /// <summary>评级id</summary>
  public uint id{ get { return _id; }}
  /// <summary>生涯能力占比 如：10表示战胜10%的玩家</summary>
  public uint percent{ get { return _percent; }}
  /// <summary>评级描述</summary>
  public string gradeName{ get { return _gradeName; }}
}
