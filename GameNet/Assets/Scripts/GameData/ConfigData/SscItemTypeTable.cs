using System;
[Serializable]
public class SscItemTypeTable :IConfig{
   private uint _id;
   private uint _itemName;
   private string _modelPath;
   private string _iconPath;
   private int _priceType;
   private int _price;
   private int _itemType;
   private string _attriValue;
   private int _target;
   private string _keepTime;
   private int _warning;
   private string _fireAction;
   private string _fireEff;
   private string _hitAction;
   private string _hitEff;
   private string _keepEff;
   private uint _describe;
   public SscItemTypeTable (uint type_id,uint type_itemName,string type_modelPath,string type_iconPath,int type_priceType,int type_price,int type_itemType,string type_attriValue,int type_target,string type_keepTime,int type_warning,string type_fireAction,string type_fireEff,string type_hitAction,string type_hitEff,string type_keepEff,uint type_describe){
     _id =  (uint)type_id;
     _itemName =  type_itemName;
     _modelPath =  type_modelPath;
     _iconPath =  type_iconPath;
     _priceType =  type_priceType;
     _price =  type_price;
     _itemType =  type_itemType;
     _attriValue =  type_attriValue;
     _target =  type_target;
     _keepTime =  type_keepTime;
     _warning =  type_warning;
     _fireAction =  type_fireAction;
     _fireEff =  type_fireEff;
     _hitAction =  type_hitAction;
     _hitEff =  type_hitEff;
     _keepEff =  type_keepEff;
     _describe =  type_describe;
   }
  /// <summary>道具ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>道具名</summary>
  public uint itemName{ get { return _itemName; }}
  /// <summary>道具对应模型</summary>
  public string modelPath{ get { return _modelPath; }}
  /// <summary>道具对应ICON</summary>
  public string iconPath{ get { return _iconPath; }}
  /// <summary>道具出售货币类型 0：金币 1：勋章 2：经验</summary>
  public int priceType{ get { return _priceType; }}
  /// <summary>道具出售价格</summary>
  public int price{ get { return _price; }}
  /// <summary>道具类型 0：瞬间加速(功能饮料) 1：瞬间减速(减速道具) 2：瞬间回复体力 3：瞬间扣除体力 4：持续回复体力 (每3秒回复n点体力) 5：持续扣除体力 (每3秒扣除n点体力) 6：防护盾 7：眩晕 8：禁止使用道具 9：摔倒 10：飞行 11：隐身 12：反弹 13:交换位置 14:冰冻</summary>
  public int itemType{ get { return _itemType; }}
  /// <summary>1星到5星道具属性数值 如：当道具类型为加速时，则属性数值表示提升最终移动速度的百分比。  如：当道具类型为眩晕时，则该单元格数值为空。 而眩晕时间则读取【1到5星道具持续时间】那一列的数值</summary>
  public string attriValue{ get { return _attriValue; }}
  /// <summary>道具作用目标 0：自身 1:前方最近的一名目标 2：最近的一名目标 3：第一名的目标 4：场上随机一名敌方目标(除了自己) 5：场上随机一名队友(包括自己) 6：场上随机一名队友(不包括自己) 7：脚下 8:全场所有敌方单位 9:全场所有右方单位</summary>
  public int target{ get { return _target; }}
  /// <summary>1星到5星道具持续时间 (秒)</summary>
  public string keepTime{ get { return _keepTime; }}
  /// <summary>道具击中目标前是否有预警 0：没有预警 大于0的数字:预警倒计时的时间</summary>
  public int warning{ get { return _warning; }}
  /// <summary>道具施法动作 若不填则表示没有施法动作</summary>
  public string fireAction{ get { return _fireAction; }}
  /// <summary>施法特效</summary>
  public string fireEff{ get { return _fireEff; }}
  /// <summary>击中动作 若不填则表示没有击中动作</summary>
  public string hitAction{ get { return _hitAction; }}
  /// <summary>击中特效</summary>
  public string hitEff{ get { return _hitEff; }}
  /// <summary>状态持续特效</summary>
  public string keepEff{ get { return _keepEff; }}
  /// <summary>道具描述</summary>
  public uint describe{ get { return _describe; }}
}
