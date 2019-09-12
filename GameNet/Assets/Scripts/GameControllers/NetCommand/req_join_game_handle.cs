using com.sporger.server.proto.model;
using Stars;
class req_join_game_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_join_game_out req_join_game_out = Net.ProtoBuf_Deserialize<req_join_game_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
