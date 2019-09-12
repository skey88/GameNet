using System;
[Serializable]
public class CareerPlotContent :IConfig{
   private uint _id;
   private uint _type;
   private uint _roleid;
   private string _plot;
   private uint _audio;
   public CareerPlotContent (uint type_id,uint type_type,uint type_roleid,string type_plot,uint type_audio){
     _id =  (uint)type_id;
     _type =  type_type;
     _roleid =  type_roleid;
     _plot =  type_plot;
     _audio =  type_audio;
   }
  /// <summary>对话ID 1.生涯剧情 2.新手引导</summary>
  public uint id{ get { return _id; }}
  /// <summary>对话类型 1.NPC（索引NPC表） 2.自己 3.教练（索引教练表）</summary>
  public uint type{ get { return _type; }}
  /// <summary>对话NPCID</summary>
  public uint roleid{ get { return _roleid; }}
  /// <summary>对话内容</summary>
  public string plot{ get { return _plot; }}
  /// <summary>音轨路径</summary>
  public uint audio{ get { return _audio; }}
}
