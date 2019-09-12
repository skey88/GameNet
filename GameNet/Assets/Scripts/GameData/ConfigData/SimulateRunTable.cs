using System;
[Serializable]
public class SimulateRunTable :IConfig{
   private uint _id;
   private uint _playerSpeed;
   private uint _playerStrideFrequency;
   public SimulateRunTable (uint type_id,uint type_playerSpeed,uint type_playerStrideFrequency){
     _id =  (uint)type_id;
     _playerSpeed =  type_playerSpeed;
     _playerStrideFrequency =  type_playerStrideFrequency;
   }
  /// <summary>ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>玩家配速 秒/公里</summary>
  public uint playerSpeed{ get { return _playerSpeed; }}
  /// <summary>玩家步频 步数/分钟</summary>
  public uint playerStrideFrequency{ get { return _playerStrideFrequency; }}
}
