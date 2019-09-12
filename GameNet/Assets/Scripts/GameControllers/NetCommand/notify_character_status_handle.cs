using com.sporger.server.proto.model;
using Stars;
class notify_character_status_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_character_status_out notify_character_status_out = Net.ProtoBuf_Deserialize<notify_character_status_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
