using System;
[Serializable]
public class LevelTable :IConfig{
   private uint _id;
   private uint _index;
   private string _levelPath;
   private string _prefabsPath;
   private uint _chapterId;
   private string _icon;
   private uint _levelName;
   private uint _zoneName;
   private uint _warmupVideoId;
   private int _levelType;
   private int _fitnessVideoId;
   private int _runDistance;
   private int _timeLimit;
   private uint _describe;
   private int _exp;
   private int _gold;
   private int _careerType;
   private string _robotId;
   private string _equips;
   private uint _sportStartCountdown;
   private uint _warmupStartCountdown;
   public LevelTable (uint type_id,uint type_index,string type_levelPath,string type_prefabsPath,uint type_chapterId,string type_icon,uint type_levelName,uint type_zoneName,uint type_warmupVideoId,int type_levelType,int type_fitnessVideoId,int type_runDistance,int type_timeLimit,uint type_describe,int type_exp,int type_gold,int type_careerType,string type_robotId,string type_equips,uint type_sportStartCountdown,uint type_warmupStartCountdown){
     _id =  (uint)type_id;
     _index =  type_index;
     _levelPath =  type_levelPath;
     _prefabsPath =  type_prefabsPath;
     _chapterId =  type_chapterId;
     _icon =  type_icon;
     _levelName =  type_levelName;
     _zoneName =  type_zoneName;
     _warmupVideoId =  type_warmupVideoId;
     _levelType =  type_levelType;
     _fitnessVideoId =  type_fitnessVideoId;
     _runDistance =  type_runDistance;
     _timeLimit =  type_timeLimit;
     _describe =  type_describe;
     _exp =  type_exp;
     _gold =  type_gold;
     _careerType =  type_careerType;
     _robotId =  type_robotId;
     _equips =  type_equips;
     _sportStartCountdown =  type_sportStartCountdown;
     _warmupStartCountdown =  type_warmupStartCountdown;
   }
  /// <summary>生涯关卡ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>关卡索引</summary>
  public uint index{ get { return _index; }}
  /// <summary>关卡对应地图</summary>
  public string levelPath{ get { return _levelPath; }}
  /// <summary>关卡对应预制件路径 该预制件用来让策划配置路径等信息</summary>
  public string prefabsPath{ get { return _prefabsPath; }}
  /// <summary>生涯所属章节</summary>
  public uint chapterId{ get { return _chapterId; }}
  /// <summary>关卡图标</summary>
  public string icon{ get { return _icon; }}
  /// <summary>生涯名 对应zhCN表对应id的字符串</summary>
  public uint levelName{ get { return _levelName; }}
  /// <summary>区域名 对应zhCN表对应id的字符串 9101的最后一位表示所属的区域</summary>
  public uint zoneName{ get { return _zoneName; }}
  /// <summary>关卡对应热身动画id</summary>
  public uint warmupVideoId{ get { return _warmupVideoId; }}
  /// <summary>关卡类型 0：跑步 1：柔韧训练 2：力量训练</summary>
  public int levelType{ get { return _levelType; }}
  /// <summary>柔韧或力量训练 动作视频id</summary>
  public int fitnessVideoId{ get { return _fitnessVideoId; }}
  /// <summary>跑步距离(米）</summary>
  public int runDistance{ get { return _runDistance; }}
  /// <summary>跑步时间限制(秒) 当前配速15分</summary>
  public int timeLimit{ get { return _timeLimit; }}
  /// <summary>关卡描述</summary>
  public uint describe{ get { return _describe; }}
  /// <summary>奖励经验</summary>
  public int exp{ get { return _exp; }}
  /// <summary>奖励金币</summary>
  public int gold{ get { return _gold; }}
  /// <summary>生涯类型 1：Normal 2：DefeatCoach 3：Match4p 4：Match6p 5：Match2V2 6：Match3V3</summary>
  public int careerType{ get { return _careerType; }}
  /// <summary>机器人id 不同机器人之间用分号隔开 null：此内容为空</summary>
  public string robotId{ get { return _robotId; }}
  /// <summary>装备配置 同一机器人的不同装备id用逗号隔开 不同机器人的装备之间用分号隔开 null：此内容为空</summary>
  public string equips{ get { return _equips; }}
  /// <summary>运动开始倒计时</summary>
  public uint sportStartCountdown{ get { return _sportStartCountdown; }}
  /// <summary>热身开始倒计时</summary>
  public uint warmupStartCountdown{ get { return _warmupStartCountdown; }}
}
