using com.sporger.server.proto.model;
using Stars;
class notify_matching_result_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_matching_result_out notify_matching_result_out = Net.ProtoBuf_Deserialize<notify_matching_result_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
