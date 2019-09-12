using com.sporger.server.proto.model;
using Stars;
class req_player_friends_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_player_friends_out req_player_friends_out = Net.ProtoBuf_Deserialize<req_player_friends_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
