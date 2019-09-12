using com.sporger.server.proto.model;
using Stars;
class notify_ready_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_ready_out notify_ready_out = Net.ProtoBuf_Deserialize<notify_ready_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
