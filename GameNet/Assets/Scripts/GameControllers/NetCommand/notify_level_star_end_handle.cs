using com.sporger.server.proto.model;
using Stars;
class notify_level_star_end_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_level_star_end_out notify_level_star_end_out = Net.ProtoBuf_Deserialize<notify_level_star_end_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
