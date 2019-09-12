using System;
[Serializable]
public class FamPropTable :IConfig{
   private uint _id;
   private uint _type;
   private uint _name;
   private uint _describe;
   private uint _treasureid;
   private string _icon;
   private string _tips;
   private string _treasurePath;
   public FamPropTable (uint type_id,uint type_type,uint type_name,uint type_describe,uint type_treasureid,string type_icon,string type_tips,string type_treasurePath){
     _id =  (uint)type_id;
     _type =  type_type;
     _name =  type_name;
     _describe =  type_describe;
     _treasureid =  type_treasureid;
     _icon =  type_icon;
     _tips =  type_tips;
     _treasurePath =  type_treasurePath;
   }
  /// <summary>3开头ID表示藏宝图道具；4开头表示线索道具</summary>
  public uint id{ get { return _id; }}
  /// <summary>1藏宝图类型；2是文字线索类型</summary>
  public uint type{ get { return _type; }}
  /// <summary>名称</summary>
  public uint name{ get { return _name; }}
  /// <summary>描述</summary>
  public uint describe{ get { return _describe; }}
  /// <summary>对应宝箱ID</summary>
  public uint treasureid{ get { return _treasureid; }}
  /// <summary>道具图标路径</summary>
  public string icon{ get { return _icon; }}
  /// <summary>显示图片路径</summary>
  public string tips{ get { return _tips; }}
  /// <summary>道具预制件路径</summary>
  public string treasurePath{ get { return _treasurePath; }}
}
