using com.sporger.server.proto.model;
using Stars;
class req_run_base_info_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_run_base_info_out req_run_base_info_out = Net.ProtoBuf_Deserialize<req_run_base_info_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
