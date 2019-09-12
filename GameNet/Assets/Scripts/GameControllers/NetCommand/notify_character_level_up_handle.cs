using com.sporger.server.proto.model;
using Stars;
class notify_character_level_up_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_character_level_up_out notify_character_level_up_out = Net.ProtoBuf_Deserialize<notify_character_level_up_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
