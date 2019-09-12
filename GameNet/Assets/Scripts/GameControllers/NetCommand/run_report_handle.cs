using com.sporger.server.proto.model;
using Stars;
class run_report_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //run_report_out run_report_out = Net.ProtoBuf_Deserialize<run_report_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
