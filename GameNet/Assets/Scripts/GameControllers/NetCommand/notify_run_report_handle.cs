using com.sporger.server.proto.model;
using Stars;
class notify_run_report_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_run_report_out notify_run_report_out = Net.ProtoBuf_Deserialize<notify_run_report_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
