using com.sporger.server.proto.model;
using Stars;
class req_free_run_end_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_free_run_end_out req_free_run_end_out = Net.ProtoBuf_Deserialize<req_free_run_end_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
