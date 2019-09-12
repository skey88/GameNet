using com.sporger.server.proto.model;
using Stars;
class notify_confirm_matching_time_out_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_confirm_matching_time_out_out notify_confirm_matching_time_out_out = Net.ProtoBuf_Deserialize<notify_confirm_matching_time_out_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
