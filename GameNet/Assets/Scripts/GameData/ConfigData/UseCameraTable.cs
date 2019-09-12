using System;
[Serializable]
public class UseCameraTable :IConfig{
   private uint _id;
   private string _gamecamera;
   private string _lockcamera;
   public UseCameraTable (uint type_id,string type_gamecamera,string type_lockcamera){
     _id =  (uint)type_id;
     _gamecamera =  type_gamecamera;
     _lockcamera =  type_lockcamera;
   }
  /// <summary>活动id: 0广场  1生涯 2自由跑 3竞速赛 4秘境寻宝 5移动迷宫 6彩虹跑  </summary>
  public uint id{ get { return _id; }}
  /// <summary>游戏镜头</summary>
  public string gamecamera{ get { return _gamecamera; }}
  /// <summary>围观镜头</summary>
  public string lockcamera{ get { return _lockcamera; }}
}
