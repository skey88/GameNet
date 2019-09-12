using System;
[Serializable]
public class EquipTable :IConfig{
   private uint _id;
   private int _equipType;
   private uint _equipName;
   private int _sex;
   private string _equipModelPath;
   private string _iconPath;
   private string _atlasName;
   private int _priceType;
   private int _price;
   private uint _describe;
   public EquipTable (uint type_id,int type_equipType,uint type_equipName,int type_sex,string type_equipModelPath,string type_iconPath,string type_atlasName,int type_priceType,int type_price,uint type_describe){
     _id =  (uint)type_id;
     _equipType =  type_equipType;
     _equipName =  type_equipName;
     _sex =  type_sex;
     _equipModelPath =  type_equipModelPath;
     _iconPath =  type_iconPath;
     _atlasName =  type_atlasName;
     _priceType =  type_priceType;
     _price =  type_price;
     _describe =  type_describe;
   }
  /// <summary>装备ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>装备类型(装备部位) 1：上衣 2：裤子 3：鞋子 4：帽子 5：腰包 6：护膝 7：眼镜 8：套袖 9：手表</summary>
  public int equipType{ get { return _equipType; }}
  /// <summary>装备名</summary>
  public uint equipName{ get { return _equipName; }}
  /// <summary>适用性别 1：女 2：男</summary>
  public int sex{ get { return _sex; }}
  /// <summary>装备对应模型</summary>
  public string equipModelPath{ get { return _equipModelPath; }}
  /// <summary>装备对应Icon</summary>
  public string iconPath{ get { return _iconPath; }}
  /// <summary>atlas图集名称</summary>
  public string atlasName{ get { return _atlasName; }}
  /// <summary>装备出售货币类型  1：金币 2：钻石</summary>
  public int priceType{ get { return _priceType; }}
  /// <summary>装备出售价格</summary>
  public int price{ get { return _price; }}
  /// <summary>装备描述</summary>
  public uint describe{ get { return _describe; }}
}
