using System;
[Serializable]
public class CareerPlotCondition :IConfig{
   private uint _id;
   private uint _levelid;
   private int _type;
   private int _condition;
   private int _conditionnumber;
   private string _plotid;
   public CareerPlotCondition (uint type_id,uint type_levelid,int type_type,int type_condition,int type_conditionnumber,string type_plotid){
     _id =  (uint)type_id;
     _levelid =  type_levelid;
     _type =  type_type;
     _condition =  type_condition;
     _conditionnumber =  type_conditionnumber;
     _plotid =  type_plotid;
   }
  /// <summary>ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>生涯关卡ID</summary>
  public uint levelid{ get { return _levelid; }}
  /// <summary>关闭条件 1.通关一次剧情关闭 2.通过本次关卡关闭</summary>
  public int type{ get { return _type; }}
  /// <summary>触发条件 1：进入关卡时（暂停） 2：热身倒计时结束时（暂停） 3：胜利结算时（暂停） 4：失败结算时（暂停） 5：关卡开始后固定时间（秒） 6：关卡固定距离（米）</summary>
  public int condition{ get { return _condition; }}
  /// <summary>触发条件数值</summary>
  public int conditionnumber{ get { return _conditionnumber; }}
  /// <summary>剧情对话ID 多角色对话内容，用;分割，顺序播放</summary>
  public string plotid{ get { return _plotid; }}
}
