using com.sporger.server.proto.model;
using Stars;
class req_friend_message_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_friend_message_out req_friend_message_out = Net.ProtoBuf_Deserialize<req_friend_message_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
