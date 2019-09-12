using System;
[Serializable]
public class MoneyTable :IConfig{
   private uint _id;
   private string _field;
   private uint _name;
   private int _number;
   private string _icon;
   private string _atlasName;
   public MoneyTable (uint type_id,string type_field,uint type_name,int type_number,string type_icon,string type_atlasName){
     _id =  (uint)type_id;
     _field =  type_field;
     _name =  type_name;
     _number =  type_number;
     _icon =  type_icon;
     _atlasName =  type_atlasName;
   }
  /// <summary>货币id</summary>
  public uint id{ get { return _id; }}
  /// <summary>货币字段</summary>
  public string field{ get { return _field; }}
  /// <summary>名称</summary>
  public uint name{ get { return _name; }}
  /// <summary>最大叠加数量</summary>
  public int number{ get { return _number; }}
  /// <summary>图标</summary>
  public string icon{ get { return _icon; }}
  /// <summary>atlas图集名称</summary>
  public string atlasName{ get { return _atlasName; }}
}
