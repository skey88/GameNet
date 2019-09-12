using System;
[Serializable]
public class RainbowTypeTable :IConfig{
   private uint _id;
   private int _type;
   private string _scene;
   private string _mapPath;
   private uint _title;
   private uint _instruction;
   private int _lv;
   private int _ticketType;
   private int _ticketNumber;
   public RainbowTypeTable (uint type_id,int type_type,string type_scene,string type_mapPath,uint type_title,uint type_instruction,int type_lv,int type_ticketType,int type_ticketNumber){
     _id =  (uint)type_id;
     _type =  type_type;
     _scene =  type_scene;
     _mapPath =  type_mapPath;
     _title =  type_title;
     _instruction =  type_instruction;
     _lv =  type_lv;
     _ticketType =  type_ticketType;
     _ticketNumber =  type_ticketNumber;
   }
  /// <summary>序号</summary>
  public uint id{ get { return _id; }}
  /// <summary>类型  1：初级 2：中级 3：高级</summary>
  public int type{ get { return _type; }}
  /// <summary>场景</summary>
  public string scene{ get { return _scene; }}
  /// <summary>场景预制件</summary>
  public string mapPath{ get { return _mapPath; }}
  /// <summary>标题 zhcn</summary>
  public uint title{ get { return _title; }}
  /// <summary>说明 zhcn</summary>
  public uint instruction{ get { return _instruction; }}
  /// <summary>等级 即，解锁等级</summary>
  public int lv{ get { return _lv; }}
  /// <summary>门票类型 0：免费 1：金币 2：钻石</summary>
  public int ticketType{ get { return _ticketType; }}
  /// <summary>门票数量</summary>
  public int ticketNumber{ get { return _ticketNumber; }}
}
