using System;
[Serializable]
public class RaceOptionTable :IConfig{
   private uint _id;
   private string _gameType;
   private string _numberOfPeople;
   private string _distance;
   public RaceOptionTable (uint type_id,string type_gameType,string type_numberOfPeople,string type_distance){
     _id =  (uint)type_id;
     _gameType =  type_gameType;
     _numberOfPeople =  type_numberOfPeople;
     _distance =  type_distance;
   }
  /// <summary>竞速赛id </summary>
  public uint id{ get { return _id; }}
  /// <summary>比赛类型 1：团队赛 2：个人赛</summary>
  public string gameType{ get { return _gameType; }}
  /// <summary>竞速赛人数 单位：人</summary>
  public string numberOfPeople{ get { return _numberOfPeople; }}
  /// <summary>跑步距离 单位：米</summary>
  public string distance{ get { return _distance; }}
}
