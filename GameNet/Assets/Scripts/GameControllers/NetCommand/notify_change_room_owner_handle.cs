using com.sporger.server.proto.model;
using Stars;
class notify_change_room_owner_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_change_room_owner_out notify_change_room_owner_out = Net.ProtoBuf_Deserialize<notify_change_room_owner_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
