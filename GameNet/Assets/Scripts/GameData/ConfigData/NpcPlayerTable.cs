using System;
[Serializable]
public class NpcPlayerTable :IConfig{
   private uint _id;
   private uint _nameId;
   private uint _sex;
   private string _photoicon;
   private uint _skeletonId;
   private uint _cityId;
   private uint _speedId;
   private string _equips;
   public NpcPlayerTable (uint type_id,uint type_nameId,uint type_sex,string type_photoicon,uint type_skeletonId,uint type_cityId,uint type_speedId,string type_equips){
     _id =  (uint)type_id;
     _nameId =  type_nameId;
     _sex =  type_sex;
     _photoicon =  type_photoicon;
     _skeletonId =  type_skeletonId;
     _cityId =  type_cityId;
     _speedId =  type_speedId;
     _equips =  type_equips;
   }
  /// <summary>NpcID  左起第1位数字代表含义  1：生涯 2：自由跑 3：竞速</summary>
  public uint id{ get { return _id; }}
  /// <summary>Npc名字id 0：系统随机生成 >0：读表ZhCn</summary>
  public uint nameId{ get { return _nameId; }}
  /// <summary>Npc性别 1：女 2：男</summary>
  public uint sex{ get { return _sex; }}
  /// <summary>头像图标</summary>
  public string photoicon{ get { return _photoicon; }}
  /// <summary>骨架id  *InitialModelTable</summary>
  public uint skeletonId{ get { return _skeletonId; }}
  /// <summary>Npc城市 0系统随机生成</summary>
  public uint cityId{ get { return _cityId; }}
  /// <summary>速度id 0：系统随机生成 >0：读表</summary>
  public uint speedId{ get { return _speedId; }}
  /// <summary>随机装备库 null：读取LevelTable 其他：随机生成</summary>
  public string equips{ get { return _equips; }}
}
