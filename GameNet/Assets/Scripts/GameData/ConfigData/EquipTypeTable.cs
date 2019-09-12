using System;
[Serializable]
public class EquipTypeTable :IConfig{
   private uint _id;
   private int _equipParType;
   private string _boneName;
   public EquipTypeTable (uint type_id,int type_equipParType,string type_boneName){
     _id =  (uint)type_id;
     _equipParType =  type_equipParType;
     _boneName =  type_boneName;
   }
  /// <summary>装备子类型  1：上衣 2：裤子 3：鞋子 4：帽子(头发) 5：腰包 6：护膝 7：眼镜 8：套袖 9：手表</summary>
  public uint id{ get { return _id; }}
  /// <summary>装备父类型  1：上衣 2：裤子 3：鞋子 4：头部饰品 5：上半身饰品 6：下半身饰品</summary>
  public int equipParType{ get { return _equipParType; }}
  /// <summary>挂载的骨骼名  不填：表示自身带有骨骼 填写：需要挂载在某骨骼上特殊物品，腕饰。 腕饰：默认是对称装备，即左右手都有。当前游戏中仅左边有，那么需要在后面加后缀_L。同理，仅右边有，加缀_R。</summary>
  public string boneName{ get { return _boneName; }}
}
