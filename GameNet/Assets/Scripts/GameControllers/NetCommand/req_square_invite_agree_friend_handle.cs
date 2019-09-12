using com.sporger.server.proto.model;
using Stars;
class req_square_invite_agree_friend_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_square_invite_agree_friend_out req_square_invite_agree_friend_out = Net.ProtoBuf_Deserialize<req_square_invite_agree_friend_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
