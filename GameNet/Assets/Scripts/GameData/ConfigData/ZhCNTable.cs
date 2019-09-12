using System;
[Serializable]
public class ZhCNTable :IConfig{
   private uint _id;
   private string _index;
   private string _Content;
   public ZhCNTable (uint type_id,string type_index,string type_Content){
     _id =  (uint)type_id;
     _index =  type_index;
     _Content =  type_Content;
   }
  /// <summary>文本内容id</summary>
  public uint id{ get { return _id; }}
  /// <summary>文本内容名</summary>
  public string index{ get { return _index; }}
  /// <summary>文本内容</summary>
  public string Content{ get { return _Content; }}
}
