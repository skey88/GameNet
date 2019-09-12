using com.sporger.server.proto.model;
using Stars;
class notify_exit_chat_group_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_exit_chat_group_out notify_exit_chat_group_out = Net.ProtoBuf_Deserialize<notify_exit_chat_group_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
