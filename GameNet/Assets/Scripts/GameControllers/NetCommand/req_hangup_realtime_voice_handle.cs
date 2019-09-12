using com.sporger.server.proto.model;
using Stars;
class req_hangup_realtime_voice_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_hangup_realtime_voice_out req_hangup_realtime_voice_out = Net.ProtoBuf_Deserialize<req_hangup_realtime_voice_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
