using com.sporger.server.proto.model;
using Stars;
class notify_close_chat_group_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_close_chat_group_out notify_close_chat_group_out = Net.ProtoBuf_Deserialize<notify_close_chat_group_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
