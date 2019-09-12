using System;
[Serializable]
public class warmupVideoTable :IConfig{
   private uint _id;
   private string _warmupActionName;
   private uint _warmupTime;
   private uint _warmupName;
   private uint _warmupDes;
   public warmupVideoTable (uint type_id,string type_warmupActionName,uint type_warmupTime,uint type_warmupName,uint type_warmupDes){
     _id =  (uint)type_id;
     _warmupActionName =  type_warmupActionName;
     _warmupTime =  type_warmupTime;
     _warmupName =  type_warmupName;
     _warmupDes =  type_warmupDes;
   }
  /// <summary>热身id</summary>
  public uint id{ get { return _id; }}
  /// <summary>热身动作名</summary>
  public string warmupActionName{ get { return _warmupActionName; }}
  /// <summary>热身动作播放（次数)</summary>
  public uint warmupTime{ get { return _warmupTime; }}
  /// <summary>热身名</summary>
  public uint warmupName{ get { return _warmupName; }}
  /// <summary>热身描述</summary>
  public uint warmupDes{ get { return _warmupDes; }}
}
