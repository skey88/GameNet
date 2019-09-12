using System;
[Serializable]
public class DailyTasksTable :IConfig{
   private uint _id;
   private uint _function;
   private uint _type;
   private uint _name;
   private uint _describe;
   private int _openlv;
   private int _closelv;
   private string _condition;
   private int _exp;
   private int _gold;
   private int _diamond;
   private string _item;
   public DailyTasksTable (uint type_id,uint type_function,uint type_type,uint type_name,uint type_describe,int type_openlv,int type_closelv,string type_condition,int type_exp,int type_gold,int type_diamond,string type_item){
     _id =  (uint)type_id;
     _function =  type_function;
     _type =  type_type;
     _name =  type_name;
     _describe =  type_describe;
     _openlv =  type_openlv;
     _closelv =  type_closelv;
     _condition =  type_condition;
     _exp =  type_exp;
     _gold =  type_gold;
     _diamond =  type_diamond;
     _item =  type_item;
   }
  /// <summary>任务id</summary>
  public uint id{ get { return _id; }}
  /// <summary>功能类型： 1：各种小功能类型 2：自由跑类型 3：竞速赛类型 4：寻宝类型 5：生涯类型</summary>
  public uint function{ get { return _function; }}
  /// <summary>任务类型： 1：完成跑前热身x次 2：完成跑后热身x次 3：关注x个玩家 4：获得x个金币 5：当天累积运动x秒 6：参加x次自由跑 7：在自由跑中累积运动x米 8：完成一次x米的自由跑，平均配速达到y秒/公里 9：完成一次x米的自由跑，平均步频达到y步/分钟 10：参加x次竞速赛 11：参加x次参赛总人数为y类型的竞速赛 12：在参赛总人数为x的竞速赛中进入前y名 13：参加x次总长为y米的竞速赛 14：参加x次秘境寻宝 15：秘境寻宝中开启x个y人数的z类型宝箱 16：当天完成x个生涯关卡</summary>
  public uint type{ get { return _type; }}
  /// <summary>任务名称</summary>
  public uint name{ get { return _name; }}
  /// <summary>任务描述</summary>
  public uint describe{ get { return _describe; }}
  /// <summary>开启等级</summary>
  public int openlv{ get { return _openlv; }}
  /// <summary>关闭等级</summary>
  public int closelv{ get { return _closelv; }}
  /// <summary>对应任务类型条件详细说明：  1：完成跑前热身x次。其中x为int类型。 2：完成跑后热身x次。其中x为int类型。 3：关注x个玩家。其中x为int类型。 4：当天累积获得x个金币。其中x为uint类型。 5：当天累积运动x秒。其中x为int类型。  注：不限运动模式。  6：参加x次自由跑。其中x为int类型。 注：单次参与自由跑的最短距离为y米，少于此距离无效。格式：x,y。  7：在自由跑中累积运动x米。其中x为int类型。 注：单次自由跑最短距离100米，少于此距离不参与累积计算。  8：完成一次x米的自由跑，平均配速达到y秒/公里。其中x,y为int类型。 注：此任务需求自由跑的距离>=x米，少于此距离无效。格式：x;y。距离十位和个位不允许填写  9：完成一次x米的自由跑，平均步频达到y步/分。其中x,y为int类型。 注：此任务需求自由跑的距离>=x米，少于此距离无效。格式：x;y。距离十位和个位不允许填写  10：参加x次竞速赛。其中x为int类型。 注：不限个人或团队赛，不限参赛总人数，不限距离。  11：参加x次参赛总人数为y类型的竞速赛。其中x,y为int类型。  注：不限个人赛或团队赛，不限距离。格式：x;y。  12：在参赛总人数为x的竞速赛中获得前y名。其中x,y为int类型。 注：不限个人或团队赛，不限距离。格式：x;y。  13：参加x次总长为y米类型的竞速赛  注：不限个人或团队赛，不限参赛总人数。格式：x;y。y距离十位和个位不允许填写。  14：参加x次秘境寻宝。其中x为int类型。 15：秘境寻宝中开启x个y类型的z宝箱  注：格式：x;y;z   x：数量   y：1，单人；2，多人   z：1，普通；2，道具（暂时不用）；3，藏宝图；4，线索 16：当天完成x个生涯关卡。其中x为int类型。</summary>
  public string condition{ get { return _condition; }}
  /// <summary>经验奖励</summary>
  public int exp{ get { return _exp; }}
  /// <summary>金币奖励</summary>
  public int gold{ get { return _gold; }}
  /// <summary>钻石奖励</summary>
  public int diamond{ get { return _diamond; }}
  /// <summary>物品奖励</summary>
  public string item{ get { return _item; }}
}
