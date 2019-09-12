using System;
[Serializable]
public class EquipSynthesisTable :IConfig{
   private uint _id;
   private int _TowStar;
   private uint _ThereStar;
   private string _FourStar;
   private string _FiveStar;
   public EquipSynthesisTable (uint type_id,int type_TowStar,uint type_ThereStar,string type_FourStar,string type_FiveStar){
     _id =  (uint)type_id;
     _TowStar =  type_TowStar;
     _ThereStar =  type_ThereStar;
     _FourStar =  type_FourStar;
     _FiveStar =  type_FiveStar;
   }
  /// <summary>装备ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>合成2星</summary>
  public int TowStar{ get { return _TowStar; }}
  /// <summary>合成3星</summary>
  public uint ThereStar{ get { return _ThereStar; }}
  /// <summary>合成4星</summary>
  public string FourStar{ get { return _FourStar; }}
  /// <summary>合成5星</summary>
  public string FiveStar{ get { return _FiveStar; }}
}
