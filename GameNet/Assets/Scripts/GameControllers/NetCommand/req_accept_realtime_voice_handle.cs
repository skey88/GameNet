using com.sporger.server.proto.model;
using Stars;
class req_accept_realtime_voice_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_accept_realtime_voice_out req_accept_realtime_voice_out = Net.ProtoBuf_Deserialize<req_accept_realtime_voice_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
