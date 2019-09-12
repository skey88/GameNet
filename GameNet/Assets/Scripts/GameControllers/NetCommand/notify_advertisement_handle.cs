using com.sporger.server.proto.model;
using Stars;
class notify_advertisement_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_advertisement_out notify_advertisement_out = Net.ProtoBuf_Deserialize<notify_advertisement_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
