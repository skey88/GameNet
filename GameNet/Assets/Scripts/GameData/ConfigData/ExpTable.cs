using System;
[Serializable]
public class ExpTable :IConfig{
   private uint _id;
   private int _lv;
   private int _exp;
   private int _cumulate;
   private int _dailyTasksExpFactor;
   private int _runExpFactor;
   public ExpTable (int type_lv,int type_exp,int type_cumulate,int type_dailyTasksExpFactor,int type_runExpFactor){
     _id =  (uint)type_lv;
     _lv =  type_lv;
     _exp =  type_exp;
     _cumulate =  type_cumulate;
     _dailyTasksExpFactor =  type_dailyTasksExpFactor;
     _runExpFactor =  type_runExpFactor;
   }
  /// <summary>玩家等级</summary>
  public uint id{ get { return _id; }}
  /// <summary>玩家等级</summary>
  public int lv{ get { return _lv; }}
  /// <summary>升级经验</summary>
  public int exp{ get { return _exp; }}
  /// <summary>当前累积升级经验</summary>
  public int cumulate{ get { return _cumulate; }}
  /// <summary>每日任务经验系数 公式：每日任务获取的经验=等级系数*基础值 基础值见DailyTasksTable.xlsx</summary>
  public int dailyTasksExpFactor{ get { return _dailyTasksExpFactor; }}
  /// <summary>跑步经验系数 1.每1公里提供的经验 2.每次跑步结算时，经验向下取整 3.任意玩法模式均运动给经验</summary>
  public int runExpFactor{ get { return _runExpFactor; }}
}
