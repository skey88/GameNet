using System;
[Serializable]
public class DropBagTable :IConfig{
   private uint _id;
   private string _Reward;
   public DropBagTable (uint type_id,string type_Reward){
     _id =  (uint)type_id;
     _Reward =  type_Reward;
   }
  /// <summary>掉落包ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>掉落包概率</summary>
  public string Reward{ get { return _Reward; }}
}
