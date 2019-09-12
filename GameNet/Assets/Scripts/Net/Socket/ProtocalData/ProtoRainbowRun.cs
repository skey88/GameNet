//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: model/ProtoRainbowRun.proto
// Note: requires additional types generated from: model/ProtoPlayer.proto
namespace com.sporger.server.proto.model
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_rainbowrun_matching_in")]
  public partial class req_rainbowrun_matching_in : global::ProtoBuf.IExtensible
  {
    public req_rainbowrun_matching_in() {}
    
    private uint _mapId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"mapId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint mapId
    {
      get { return _mapId; }
      set { _mapId = value; }
    }
    private uint _gameType;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"gameType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint gameType
    {
      get { return _gameType; }
      set { _gameType = value; }
    }
    private uint _time;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint time
    {
      get { return _time; }
      set { _time = value; }
    }
    private uint _people;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"people", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint people
    {
      get { return _people; }
      set { _people = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_rainbowrun_matching_out")]
  public partial class req_rainbowrun_matching_out : global::ProtoBuf.IExtensible
  {
    public req_rainbowrun_matching_out() {}
    
    private ulong _matchingID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"matchingID", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong matchingID
    {
      get { return _matchingID; }
      set { _matchingID = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"notify_rainbowrun_matching_result_out")]
  public partial class notify_rainbowrun_matching_result_out : global::ProtoBuf.IExtensible
  {
    public notify_rainbowrun_matching_result_out() {}
    
    private bool _isSuc;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"isSuc", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isSuc
    {
      get { return _isSuc; }
      set { _isSuc = value; }
    }
    private ulong _roomID;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"roomID", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong roomID
    {
      get { return _roomID; }
      set { _roomID = value; }
    }
    private readonly global::System.Collections.Generic.List<com.sporger.server.proto.model.player_simple_info> _playerList = new global::System.Collections.Generic.List<com.sporger.server.proto.model.player_simple_info>();
    [global::ProtoBuf.ProtoMember(3, Name=@"playerList", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<com.sporger.server.proto.model.player_simple_info> playerList
    {
      get { return _playerList; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_rainbowrun_cancel_matching_in")]
  public partial class req_rainbowrun_cancel_matching_in : global::ProtoBuf.IExtensible
  {
    public req_rainbowrun_cancel_matching_in() {}
    
    private ulong _matchingID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"matchingID", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong matchingID
    {
      get { return _matchingID; }
      set { _matchingID = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_rainbowrun_change_track_in")]
  public partial class req_rainbowrun_change_track_in : global::ProtoBuf.IExtensible
  {
    public req_rainbowrun_change_track_in() {}
    
    private uint _desTrack;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"desTrack", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint desTrack
    {
      get { return _desTrack; }
      set { _desTrack = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_rainbowrun_change_track_out")]
  public partial class req_rainbowrun_change_track_out : global::ProtoBuf.IExtensible
  {
    public req_rainbowrun_change_track_out() {}
    
    private uint _desTrack;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"desTrack", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint desTrack
    {
      get { return _desTrack; }
      set { _desTrack = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"notify_rainbowrun_change_track_out")]
  public partial class notify_rainbowrun_change_track_out : global::ProtoBuf.IExtensible
  {
    public notify_rainbowrun_change_track_out() {}
    
    private string _playerId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"playerId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string playerId
    {
      get { return _playerId; }
      set { _playerId = value; }
    }
    private uint _desTrack;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"desTrack", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint desTrack
    {
      get { return _desTrack; }
      set { _desTrack = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"rainbowrun_cur_player_info")]
  public partial class rainbowrun_cur_player_info : global::ProtoBuf.IExtensible
  {
    public rainbowrun_cur_player_info() {}
    
    private string _playerId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"playerId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string playerId
    {
      get { return _playerId; }
      set { _playerId = value; }
    }
    private int _area;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"area", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int area
    {
      get { return _area; }
      set { _area = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"notify_rainbowrun_current_info_out")]
  public partial class notify_rainbowrun_current_info_out : global::ProtoBuf.IExtensible
  {
    public notify_rainbowrun_current_info_out() {}
    
    private readonly global::System.Collections.Generic.List<string> _rainbowrun_cur_player_info = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(1, Name=@"rainbowrun_cur_player_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> rainbowrun_cur_player_info
    {
      get { return _rainbowrun_cur_player_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"rainbow_game_result")]
  public partial class rainbow_game_result : global::ProtoBuf.IExtensible
  {
    public rainbow_game_result() {}
    
    private string _playerId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"playerId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string playerId
    {
      get { return _playerId; }
      set { _playerId = value; }
    }
    private int _score;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int score
    {
      get { return _score; }
      set { _score = value; }
    }
    private int _rewardScore;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"rewardScore", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int rewardScore
    {
      get { return _rewardScore; }
      set { _rewardScore = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"notify_rainbowrun_gameover_out")]
  public partial class notify_rainbowrun_gameover_out : global::ProtoBuf.IExtensible
  {
    public notify_rainbowrun_gameover_out() {}
    
    private readonly global::System.Collections.Generic.List<com.sporger.server.proto.model.rainbow_game_result> _result = new global::System.Collections.Generic.List<com.sporger.server.proto.model.rainbow_game_result>();
    [global::ProtoBuf.ProtoMember(1, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<com.sporger.server.proto.model.rainbow_game_result> result
    {
      get { return _result; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"notify_rainbowrun_ready_out")]
  public partial class notify_rainbowrun_ready_out : global::ProtoBuf.IExtensible
  {
    public notify_rainbowrun_ready_out() {}
    
    private string _playerId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"playerId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string playerId
    {
      get { return _playerId; }
      set { _playerId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"notify_rainbowrun_load_scene_out")]
  public partial class notify_rainbowrun_load_scene_out : global::ProtoBuf.IExtensible
  {
    public notify_rainbowrun_load_scene_out() {}
    
    private ulong _roomID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"roomID", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong roomID
    {
      get { return _roomID; }
      set { _roomID = value; }
    }
    private string _channelId;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"channelId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string channelId
    {
      get { return _channelId; }
      set { _channelId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}