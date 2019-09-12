using System;
[Serializable]
public class RainbowOptionTable :IConfig{
   private uint _id;
   private string _gameType;
   private string _numberOfPeople;
   private string _time;
   public RainbowOptionTable (uint type_id,string type_gameType,string type_numberOfPeople,string type_time){
     _id =  (uint)type_id;
     _gameType =  type_gameType;
     _numberOfPeople =  type_numberOfPeople;
     _time =  type_time;
   }
  /// <summary>彩虹跑id </summary>
  public uint id{ get { return _id; }}
  /// <summary>比赛类型 1：团队赛 2：个人赛</summary>
  public string gameType{ get { return _gameType; }}
  /// <summary>彩虹跑人数 单位：人</summary>
  public string numberOfPeople{ get { return _numberOfPeople; }}
  /// <summary>时长 单位：分钟</summary>
  public string time{ get { return _time; }}
}
