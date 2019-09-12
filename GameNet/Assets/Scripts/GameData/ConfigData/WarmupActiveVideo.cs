using System;
[Serializable]
public class WarmupActiveVideo :IConfig{
   private uint _id;
   private string _warmupActionName;
   public WarmupActiveVideo (uint type_id,string type_warmupActionName){
     _id =  (uint)type_id;
     _warmupActionName =  type_warmupActionName;
   }
  /// <summary>生涯及自由跑热身组ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>热身动作ID</summary>
  public string warmupActionName{ get { return _warmupActionName; }}
}
