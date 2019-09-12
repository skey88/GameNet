using com.sporger.server.proto.model;
using Stars;
class req_enter_square_chat_group_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_enter_square_chat_group_out req_enter_square_chat_group_out = Net.ProtoBuf_Deserialize<req_enter_square_chat_group_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
