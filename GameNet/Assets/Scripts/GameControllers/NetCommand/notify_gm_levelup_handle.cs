using com.sporger.server.proto.model;
using Stars;
class notify_gm_levelup_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_gm_levelup_out notify_gm_levelup_out = Net.ProtoBuf_Deserialize<notify_gm_levelup_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
