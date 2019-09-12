using com.sporger.server.proto.model;
using Stars;
class notify_pick_open_treasure_item_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_pick_open_treasure_item_out notify_pick_open_treasure_item_out = Net.ProtoBuf_Deserialize<notify_pick_open_treasure_item_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
