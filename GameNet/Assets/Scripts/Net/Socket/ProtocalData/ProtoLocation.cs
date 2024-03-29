//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: model/ProtoLocation.proto
// Note: requires additional types generated from: model/ProtoCommon.proto
namespace com.sporger.server.proto.model
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"location_in")]
  public partial class location_in : global::ProtoBuf.IExtensible
  {
    public location_in() {}
    
    private float _longitude = default(float);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"longitude", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float longitude
    {
      get { return _longitude; }
      set { _longitude = value; }
    }
    private float _latitude = default(float);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"latitude", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float latitude
    {
      get { return _latitude; }
      set { _latitude = value; }
    }
    private float _distance;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"distance", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float distance
    {
      get { return _distance; }
      set { _distance = value; }
    }
    private ulong _timeStamp;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"timeStamp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong timeStamp
    {
      get { return _timeStamp; }
      set { _timeStamp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"vector3")]
  public partial class vector3 : global::ProtoBuf.IExtensible
  {
    public vector3() {}
    
    private float _x;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"x", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float x
    {
      get { return _x; }
      set { _x = value; }
    }
    private float _y;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"y", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float y
    {
      get { return _y; }
      set { _y = value; }
    }
    private float _z;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"z", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float z
    {
      get { return _z; }
      set { _z = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"vector2")]
  public partial class vector2 : global::ProtoBuf.IExtensible
  {
    public vector2() {}
    
    private float _x;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"x", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float x
    {
      get { return _x; }
      set { _x = value; }
    }
    private float _y;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"y", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float y
    {
      get { return _y; }
      set { _y = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"character_status")]
  public partial class character_status : global::ProtoBuf.IExtensible
  {
    public character_status() {}
    
    private string _playerId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"playerId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string playerId
    {
      get { return _playerId; }
      set { _playerId = value; }
    }
    private com.sporger.server.proto.model.vector3 _position;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"position", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.vector3 position
    {
      get { return _position; }
      set { _position = value; }
    }
    private com.sporger.server.proto.model.vector3 _velocity;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"velocity", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.vector3 velocity
    {
      get { return _velocity; }
      set { _velocity = value; }
    }
    private com.sporger.server.proto.model.CharacterState _characterState;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"characterState", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public com.sporger.server.proto.model.CharacterState characterState
    {
      get { return _characterState; }
      set { _characterState = value; }
    }
    private ulong _timeStamp;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"timeStamp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong timeStamp
    {
      get { return _timeStamp; }
      set { _timeStamp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"character_status_in")]
  public partial class character_status_in : global::ProtoBuf.IExtensible
  {
    public character_status_in() {}
    
    private ulong _roomId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"roomId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong roomId
    {
      get { return _roomId; }
      set { _roomId = value; }
    }
    private com.sporger.server.proto.model.vector3 _position;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"position", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.vector3 position
    {
      get { return _position; }
      set { _position = value; }
    }
    private com.sporger.server.proto.model.vector3 _velocity;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"velocity", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.vector3 velocity
    {
      get { return _velocity; }
      set { _velocity = value; }
    }
    private com.sporger.server.proto.model.CharacterState _characterState;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"characterState", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public com.sporger.server.proto.model.CharacterState characterState
    {
      get { return _characterState; }
      set { _characterState = value; }
    }
    private ulong _timeStamp;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"timeStamp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong timeStamp
    {
      get { return _timeStamp; }
      set { _timeStamp = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_character_status_in")]
  public partial class req_character_status_in : global::ProtoBuf.IExtensible
  {
    public req_character_status_in() {}
    
    private com.sporger.server.proto.model.character_status_in _chrStatus;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"chrStatus", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.character_status_in chrStatus
    {
      get { return _chrStatus; }
      set { _chrStatus = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_maze_character_status_in")]
  public partial class req_maze_character_status_in : global::ProtoBuf.IExtensible
  {
    public req_maze_character_status_in() {}
    
    private com.sporger.server.proto.model.character_status_in _chrStatus;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"chrStatus", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.character_status_in chrStatus
    {
      get { return _chrStatus; }
      set { _chrStatus = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_city_character_status_in")]
  public partial class req_city_character_status_in : global::ProtoBuf.IExtensible
  {
    public req_city_character_status_in() {}
    
    private com.sporger.server.proto.model.character_status_in _chrStatus;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"chrStatus", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.character_status_in chrStatus
    {
      get { return _chrStatus; }
      set { _chrStatus = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_rainbow_run_character_status_in")]
  public partial class req_rainbow_run_character_status_in : global::ProtoBuf.IExtensible
  {
    public req_rainbow_run_character_status_in() {}
    
    private com.sporger.server.proto.model.character_status_in _chrStatus;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"chrStatus", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.character_status_in chrStatus
    {
      get { return _chrStatus; }
      set { _chrStatus = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"notify_character_status_out")]
  public partial class notify_character_status_out : global::ProtoBuf.IExtensible
  {
    public notify_character_status_out() {}
    
    private readonly global::System.Collections.Generic.List<com.sporger.server.proto.model.character_status> _statuslist = new global::System.Collections.Generic.List<com.sporger.server.proto.model.character_status>();
    [global::ProtoBuf.ProtoMember(1, Name=@"statuslist", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<com.sporger.server.proto.model.character_status> statuslist
    {
      get { return _statuslist; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}