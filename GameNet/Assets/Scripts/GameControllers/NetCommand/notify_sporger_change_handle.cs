using com.sporger.server.proto.model;
using Stars;
class notify_sporger_change_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_sporger_change_out notify_sporger_change_out = Net.ProtoBuf_Deserialize<notify_sporger_change_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
