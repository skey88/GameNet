using System;
[Serializable]
public class ValueTable :IConfig{
   private uint _id;
   private string _value;
   private string _unit;
   public ValueTable (uint type_id,string type_value,string type_unit){
     _id =  (uint)type_id;
     _value =  type_value;
     _unit =  type_unit;
   }
  /// <summary>id</summary>
  public uint id{ get { return _id; }}
  /// <summary>值</summary>
  public string value{ get { return _value; }}
  /// <summary>单位</summary>
  public string unit{ get { return _unit; }}
}
