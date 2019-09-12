using System;
[Serializable]
public class CoachTable :IConfig{
   private uint _id;
   private uint _nameId;
   private int _sex;
   private uint _skeletonId;
   public CoachTable (uint type_id,uint type_nameId,int type_sex,uint type_skeletonId){
     _id =  (uint)type_id;
     _nameId =  type_nameId;
     _sex =  type_sex;
     _skeletonId =  type_skeletonId;
   }
  /// <summary>教练id</summary>
  public uint id{ get { return _id; }}
  /// <summary>Npc名字id 0：系统随机生成 >0：读表ZhCn</summary>
  public uint nameId{ get { return _nameId; }}
  /// <summary>Npc性别 1：女 2：男</summary>
  public int sex{ get { return _sex; }}
  /// <summary>骨架id  *InitialModelTable</summary>
  public uint skeletonId{ get { return _skeletonId; }}
}
