using com.sporger.server.proto.model;
using Stars;
class notify_open_treasure_box_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_open_treasure_box_out notify_open_treasure_box_out = Net.ProtoBuf_Deserialize<notify_open_treasure_box_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
