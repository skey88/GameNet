using com.sporger.server.proto.model;
using Stars;
class req_cancel_matching_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_cancel_matching_out req_cancel_matching_out = Net.ProtoBuf_Deserialize<req_cancel_matching_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
