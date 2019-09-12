using com.sporger.server.proto.model;
using Stars;
class notify_realtime_voice_req_failure_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_realtime_voice_req_failure_out notify_realtime_voice_req_failure_out = Net.ProtoBuf_Deserialize<notify_realtime_voice_req_failure_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
