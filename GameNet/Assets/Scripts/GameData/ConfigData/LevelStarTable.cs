using System;
[Serializable]
public class LevelStarTable :IConfig{
   private uint _id;
   private uint _LevelID;
   private int _levelType;
   private int _judge;
   private string _condition;
   private int _describe;
   private uint _reward;
   private int _number;
   public LevelStarTable (uint type_id,uint type_LevelID,int type_levelType,int type_judge,string type_condition,int type_describe,uint type_reward,int type_number){
     _id =  (uint)type_id;
     _LevelID =  type_LevelID;
     _levelType =  type_levelType;
     _judge =  type_judge;
     _condition =  type_condition;
     _describe =  type_describe;
     _reward =  type_reward;
     _number =  type_number;
   }
  /// <summary>星级任务id  此id除以10向下取整得到星级检索id</summary>
  public uint id{ get { return _id; }}
  /// <summary>对应关卡id</summary>
  public uint LevelID{ get { return _LevelID; }}
  /// <summary>星级任务类型 1：最高配速(秒/千米) 2：平均配速(秒/千米) 3：比赛名次 注：可用于战胜教练，获得第1名 4：战胜指定npc 5：平均步频(步/分) 6：完成x公里（米） 7：实时配速在一定范围内 即，已x配速为目标，实时配速小于y 速度上下界x1和x2逗号隔开 或：与npc实时配速小于n秒 8：角色所在队伍比赛获胜 即，角色所在队伍名次为第1 9：完成跑前热身 10：击败排行榜x%人 注：x%，需要程序/100 11：完成剧情对话</summary>
  public int levelType{ get { return _levelType; }}
  /// <summary>判断机制  1：小于 2：大于 3：等于 4：小于等于 5：大于等于 6：范围（不包含边界）</summary>
  public int judge{ get { return _judge; }}
  /// <summary>条件值</summary>
  public string condition{ get { return _condition; }}
  /// <summary>描述</summary>
  public int describe{ get { return _describe; }}
  /// <summary>奖励道具id</summary>
  public uint reward{ get { return _reward; }}
  /// <summary>数量</summary>
  public int number{ get { return _number; }}
}
