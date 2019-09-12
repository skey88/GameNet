using com.sporger.server.proto.model;
using Stars;
class req_warm_body_finish_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_warm_body_finish_out req_warm_body_finish_out = Net.ProtoBuf_Deserialize<req_warm_body_finish_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
