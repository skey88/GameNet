using com.sporger.server.proto.model;
using Stars;
class notify_square_chat_info_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_square_chat_info_out notify_square_chat_info_out = Net.ProtoBuf_Deserialize<notify_square_chat_info_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
