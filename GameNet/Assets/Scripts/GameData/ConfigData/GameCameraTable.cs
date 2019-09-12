using System;
[Serializable]
public class GameCameraTable :IConfig{
   private uint _id;
   private uint _camera;
   private float _pitch;
   private float _distance;
   private float _cameraRotationSpeed;
   private float _camOffsetSpeed;
   public GameCameraTable (uint type_camera,float type_pitch,float type_distance,float type_cameraRotationSpeed,float type_camOffsetSpeed){
     _id =  (uint)type_camera;
     _camera =  type_camera;
     _pitch =  type_pitch;
     _distance =  type_distance;
     _cameraRotationSpeed =  type_cameraRotationSpeed;
     _camOffsetSpeed =  type_camOffsetSpeed;
   }
  /// <summary>游戏镜头id</summary>
  public uint id{ get { return _id; }}
  /// <summary>游戏镜头id</summary>
  public uint camera{ get { return _camera; }}
  /// <summary>俯仰参数</summary>
  public float pitch{ get { return _pitch; }}
  /// <summary>相对角色距离</summary>
  public float distance{ get { return _distance; }}
  /// <summary>水平旋转跟随角色速度</summary>
  public float cameraRotationSpeed{ get { return _cameraRotationSpeed; }}
  /// <summary>前后跟随速度</summary>
  public float camOffsetSpeed{ get { return _camOffsetSpeed; }}
}
