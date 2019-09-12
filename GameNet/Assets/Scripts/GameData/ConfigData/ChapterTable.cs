using System;
[Serializable]
public class ChapterTable :IConfig{
   private uint _id;
   private uint _chapterName;
   private uint _chapter;
   private uint _landmarkid;
   private uint _describe;
   private int _levelQuantity;
   private string _chaptericon;
   private string _landmark;
   private string _background;
   private string _position;
   public ChapterTable (uint type_id,uint type_chapterName,uint type_chapter,uint type_landmarkid,uint type_describe,int type_levelQuantity,string type_chaptericon,string type_landmark,string type_background,string type_position){
     _id =  (uint)type_id;
     _chapterName =  type_chapterName;
     _chapter =  type_chapter;
     _landmarkid =  type_landmarkid;
     _describe =  type_describe;
     _levelQuantity =  type_levelQuantity;
     _chaptericon =  type_chaptericon;
     _landmark =  type_landmark;
     _background =  type_background;
     _position =  type_position;
   }
  /// <summary>章节ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>章节名</summary>
  public uint chapterName{ get { return _chapterName; }}
  /// <summary>章节英文名</summary>
  public uint chapter{ get { return _chapter; }}
  /// <summary>地标名</summary>
  public uint landmarkid{ get { return _landmarkid; }}
  /// <summary>章节描述 对应zhCN表中对应字符串</summary>
  public uint describe{ get { return _describe; }}
  /// <summary>章节子关卡数</summary>
  public int levelQuantity{ get { return _levelQuantity; }}
  /// <summary>章节图标</summary>
  public string chaptericon{ get { return _chaptericon; }}
  /// <summary>章节地标</summary>
  public string landmark{ get { return _landmark; }}
  /// <summary>章节背景图</summary>
  public string background{ get { return _background; }}
  /// <summary>地图点坐标</summary>
  public string position{ get { return _position; }}
}
