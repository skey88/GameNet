using System;
[Serializable]
public class AttributeTable :IConfig{
   private uint _id;
   private uint _name;
   private uint _describe;
   private float _value;
   private int _Overlay;
   private int _toplimit;
   public AttributeTable (uint type_id,uint type_name,uint type_describe,float type_value,int type_Overlay,int type_toplimit){
     _id =  (uint)type_id;
     _name =  type_name;
     _describe =  type_describe;
     _value =  type_value;
     _Overlay =  type_Overlay;
     _toplimit =  type_toplimit;
   }
  /// <summary>属性ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>属性名</summary>
  public uint name{ get { return _name; }}
  /// <summary>属性描述</summary>
  public uint describe{ get { return _describe; }}
  /// <summary>属性数值</summary>
  public float value{ get { return _value; }}
  /// <summary>是否可叠加 0：不可叠加 1：可叠加</summary>
  public int Overlay{ get { return _Overlay; }}
  /// <summary>叠加上限 0：表示无叠加上限</summary>
  public int toplimit{ get { return _toplimit; }}
}
