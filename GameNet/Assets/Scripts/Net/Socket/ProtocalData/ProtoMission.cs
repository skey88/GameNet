//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: model/ProtoMission.proto
namespace com.sporger.server.proto.model
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"daily_mission_base_info")]
  public partial class daily_mission_base_info : global::ProtoBuf.IExtensible
  {
    public daily_mission_base_info() {}
    
    private uint _missionId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"missionId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint missionId
    {
      get { return _missionId; }
      set { _missionId = value; }
    }
    private int _missionState;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"missionState", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int missionState
    {
      get { return _missionState; }
      set { _missionState = value; }
    }
    private int _missionProgress;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"missionProgress", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int missionProgress
    {
      get { return _missionProgress; }
      set { _missionProgress = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_daily_mission_list_out")]
  public partial class req_daily_mission_list_out : global::ProtoBuf.IExtensible
  {
    public req_daily_mission_list_out() {}
    
    private readonly global::System.Collections.Generic.List<com.sporger.server.proto.model.daily_mission_base_info> _mission = new global::System.Collections.Generic.List<com.sporger.server.proto.model.daily_mission_base_info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"mission", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<com.sporger.server.proto.model.daily_mission_base_info> mission
    {
      get { return _mission; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_daily_mission_reward_in")]
  public partial class req_daily_mission_reward_in : global::ProtoBuf.IExtensible
  {
    public req_daily_mission_reward_in() {}
    
    private uint _missionId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"missionId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint missionId
    {
      get { return _missionId; }
      set { _missionId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_daily_mission_reward_out")]
  public partial class req_daily_mission_reward_out : global::ProtoBuf.IExtensible
  {
    public req_daily_mission_reward_out() {}
    
    private com.sporger.server.proto.model.daily_mission_base_info _mission;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"mission", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.daily_mission_base_info mission
    {
      get { return _mission; }
      set { _mission = value; }
    }
    private int _exp = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"exp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int exp
    {
      get { return _exp; }
      set { _exp = value; }
    }
    private int _gold = default(int);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"gold", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int gold
    {
      get { return _gold; }
      set { _gold = value; }
    }
    private int _diamond = default(int);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"diamond", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int diamond
    {
      get { return _diamond; }
      set { _diamond = value; }
    }
    private uint _equipId = default(uint);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"equipId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint equipId
    {
      get { return _equipId; }
      set { _equipId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"notify_daily_mission_finish")]
  public partial class notify_daily_mission_finish : global::ProtoBuf.IExtensible
  {
    public notify_daily_mission_finish() {}
    
    private com.sporger.server.proto.model.daily_mission_base_info _mission;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"mission", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.daily_mission_base_info mission
    {
      get { return _mission; }
      set { _mission = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}