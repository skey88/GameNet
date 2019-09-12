using com.sporger.server.proto.model;
using Stars;
class notify_cancel_realtime_voice_req_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_cancel_realtime_voice_req_out notify_cancel_realtime_voice_req_out = Net.ProtoBuf_Deserialize<notify_cancel_realtime_voice_req_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
