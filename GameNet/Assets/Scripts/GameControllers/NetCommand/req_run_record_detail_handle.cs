using com.sporger.server.proto.model;
using Stars;
class req_run_record_detail_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_run_record_detail_out req_run_record_detail_out = Net.ProtoBuf_Deserialize<req_run_record_detail_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
