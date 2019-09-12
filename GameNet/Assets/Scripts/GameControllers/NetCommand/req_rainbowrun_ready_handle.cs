using com.sporger.server.proto.model;
using Stars;
class req_rainbowrun_ready_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_rainbowrun_ready_out req_rainbowrun_ready_out = Net.ProtoBuf_Deserialize<req_rainbowrun_ready_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
