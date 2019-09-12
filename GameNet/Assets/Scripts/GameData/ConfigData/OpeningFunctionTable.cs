using System;
[Serializable]
public class OpeningFunctionTable :IConfig{
   private uint _id;
   private int _lv;
   private string _describe;
   private string _icon;
   private string _panelid;
   private string _prompt;
   public OpeningFunctionTable (uint type_id,int type_lv,string type_describe,string type_icon,string type_panelid,string type_prompt){
     _id =  (uint)type_id;
     _lv =  type_lv;
     _describe =  type_describe;
     _icon =  type_icon;
     _panelid =  type_panelid;
     _prompt =  type_prompt;
   }
  /// <summary>开启功能编号ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>玩家等级</summary>
  public int lv{ get { return _lv; }}
  /// <summary>功能描述</summary>
  public string describe{ get { return _describe; }}
  /// <summary>功能图标</summary>
  public string icon{ get { return _icon; }}
  /// <summary>功能ID</summary>
  public string panelid{ get { return _panelid; }}
  /// <summary>未开启提示</summary>
  public string prompt{ get { return _prompt; }}
}
