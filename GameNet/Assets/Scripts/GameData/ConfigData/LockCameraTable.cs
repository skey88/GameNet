using System;
[Serializable]
public class LockCameraTable :IConfig{
   private uint _id;
   private string _localPosition;
   private string _localDirection;
   public LockCameraTable (uint type_id,string type_localPosition,string type_localDirection){
     _id =  (uint)type_id;
     _localPosition =  type_localPosition;
     _localDirection =  type_localDirection;
   }
  /// <summary>围观镜头ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>相对位置</summary>
  public string localPosition{ get { return _localPosition; }}
  /// <summary>相对方向</summary>
  public string localDirection{ get { return _localDirection; }}
}
