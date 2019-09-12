using System;
[Serializable]
public class FamManyPointEffectTable :IConfig{
   private uint _id;
   private string _closeprefab;
   private string _openprefab;
   public FamManyPointEffectTable (uint type_id,string type_closeprefab,string type_openprefab){
     _id =  (uint)type_id;
     _closeprefab =  type_closeprefab;
     _openprefab =  type_openprefab;
   }
  /// <summary>多人宝箱挖取点位编号ID</summary>
  public uint id{ get { return _id; }}
  /// <summary>常态表现特效预制件</summary>
  public string closeprefab{ get { return _closeprefab; }}
  /// <summary>激活表现特效预制件</summary>
  public string openprefab{ get { return _openprefab; }}
}
