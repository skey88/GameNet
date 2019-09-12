using com.sporger.server.proto.model;
using Stars;
class notify_be_kicked_off_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_be_kicked_off_out notify_be_kicked_off_out = Net.ProtoBuf_Deserialize<notify_be_kicked_off_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
