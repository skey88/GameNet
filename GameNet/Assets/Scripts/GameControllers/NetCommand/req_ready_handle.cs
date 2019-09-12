using com.sporger.server.proto.model;
using Stars;
class req_ready_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_ready_out req_ready_out = Net.ProtoBuf_Deserialize<req_ready_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
