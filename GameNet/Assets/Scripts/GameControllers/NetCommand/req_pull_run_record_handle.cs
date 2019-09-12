using com.sporger.server.proto.model;
using Stars;
class req_pull_run_record_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_pull_run_record_out req_pull_run_record_out = Net.ProtoBuf_Deserialize<req_pull_run_record_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
