//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: model/ProtoBag.proto
namespace com.sporger.server.proto.model
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"game_item_info")]
  public partial class game_item_info : global::ProtoBuf.IExtensible
  {
    public game_item_info() {}
    
    private uint _itemId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"itemId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint itemId
    {
      get { return _itemId; }
      set { _itemId = value; }
    }
    private uint _number;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"number", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint number
    {
      get { return _number; }
      set { _number = value; }
    }
    private uint _time;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint time
    {
      get { return _time; }
      set { _time = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"game_item_detail_info")]
  public partial class game_item_detail_info : global::ProtoBuf.IExtensible
  {
    public game_item_detail_info() {}
    
    private com.sporger.server.proto.model.game_item_info _item;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.game_item_info item
    {
      get { return _item; }
      set { _item = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_sell_item_in")]
  public partial class req_sell_item_in : global::ProtoBuf.IExtensible
  {
    public req_sell_item_in() {}
    
    private uint _itemId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"itemId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint itemId
    {
      get { return _itemId; }
      set { _itemId = value; }
    }
    private uint _itemType;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"itemType", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint itemType
    {
      get { return _itemType; }
      set { _itemType = value; }
    }
    private uint _number;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"number", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint number
    {
      get { return _number; }
      set { _number = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_sell_item_out")]
  public partial class req_sell_item_out : global::ProtoBuf.IExtensible
  {
    public req_sell_item_out() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_use_item_in")]
  public partial class req_use_item_in : global::ProtoBuf.IExtensible
  {
    public req_use_item_in() {}
    
    private uint _itemId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"itemId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint itemId
    {
      get { return _itemId; }
      set { _itemId = value; }
    }
    private uint _number;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"number", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint number
    {
      get { return _number; }
      set { _number = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_use_item_out")]
  public partial class req_use_item_out : global::ProtoBuf.IExtensible
  {
    public req_use_item_out() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"star_up_cost_materials")]
  public partial class star_up_cost_materials : global::ProtoBuf.IExtensible
  {
    public star_up_cost_materials() {}
    
    private uint _itemId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"itemId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint itemId
    {
      get { return _itemId; }
      set { _itemId = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_show_draw_info_in")]
  public partial class req_show_draw_info_in : global::ProtoBuf.IExtensible
  {
    public req_show_draw_info_in() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_show_draw_info_out")]
  public partial class req_show_draw_info_out : global::ProtoBuf.IExtensible
  {
    public req_show_draw_info_out() {}
    
    private uint _oneStarGolTime;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"oneStarGolTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint oneStarGolTime
    {
      get { return _oneStarGolTime; }
      set { _oneStarGolTime = value; }
    }
    private uint _oneStarDiamondtime;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"oneStarDiamondtime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint oneStarDiamondtime
    {
      get { return _oneStarDiamondtime; }
      set { _oneStarDiamondtime = value; }
    }
    private uint _twoStarGoldTime;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"twoStarGoldTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint twoStarGoldTime
    {
      get { return _twoStarGoldTime; }
      set { _twoStarGoldTime = value; }
    }
    private uint _twoStarDiamondTime;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"twoStarDiamondTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint twoStarDiamondTime
    {
      get { return _twoStarDiamondTime; }
      set { _twoStarDiamondTime = value; }
    }
    private uint _threeStarGoldTime;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"threeStarGoldTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint threeStarGoldTime
    {
      get { return _threeStarGoldTime; }
      set { _threeStarGoldTime = value; }
    }
    private uint _threeStarDiamondTime;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"threeStarDiamondTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint threeStarDiamondTime
    {
      get { return _threeStarDiamondTime; }
      set { _threeStarDiamondTime = value; }
    }
    private uint _fourStarGoldTime;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"fourStarGoldTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint fourStarGoldTime
    {
      get { return _fourStarGoldTime; }
      set { _fourStarGoldTime = value; }
    }
    private uint _fourStarDiamondTime;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"fourStarDiamondTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint fourStarDiamondTime
    {
      get { return _fourStarDiamondTime; }
      set { _fourStarDiamondTime = value; }
    }
    private uint _fiveStarGoldTime;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"fiveStarGoldTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint fiveStarGoldTime
    {
      get { return _fiveStarGoldTime; }
      set { _fiveStarGoldTime = value; }
    }
    private uint _fiveStarDiamondTime;
    [global::ProtoBuf.ProtoMember(10, IsRequired = true, Name=@"fiveStarDiamondTime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint fiveStarDiamondTime
    {
      get { return _fiveStarDiamondTime; }
      set { _fiveStarDiamondTime = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_draw_reward_in")]
  public partial class req_draw_reward_in : global::ProtoBuf.IExtensible
  {
    public req_draw_reward_in() {}
    
    private uint _Id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"Id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint Id
    {
      get { return _Id; }
      set { _Id = value; }
    }
    private uint _star;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"star", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint star
    {
      get { return _star; }
      set { _star = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"req_draw_reward_out")]
  public partial class req_draw_reward_out : global::ProtoBuf.IExtensible
  {
    public req_draw_reward_out() {}
    
    private com.sporger.server.proto.model.game_item_detail_info _equip;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"equip", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public com.sporger.server.proto.model.game_item_detail_info equip
    {
      get { return _equip; }
      set { _equip = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"item_simple_info")]
  public partial class item_simple_info : global::ProtoBuf.IExtensible
  {
    public item_simple_info() {}
    
    private uint _itemId;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"itemId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint itemId
    {
      get { return _itemId; }
      set { _itemId = value; }
    }
    private uint _itemCount;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"itemCount", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint itemCount
    {
      get { return _itemCount; }
      set { _itemCount = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"notify_get_reward_out")]
  public partial class notify_get_reward_out : global::ProtoBuf.IExtensible
  {
    public notify_get_reward_out() {}
    
    private readonly global::System.Collections.Generic.List<com.sporger.server.proto.model.item_simple_info> _itemList = new global::System.Collections.Generic.List<com.sporger.server.proto.model.item_simple_info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"itemList", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<com.sporger.server.proto.model.item_simple_info> itemList
    {
      get { return _itemList; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}