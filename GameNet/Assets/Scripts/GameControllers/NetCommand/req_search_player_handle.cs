using com.sporger.server.proto.model;
using Stars;
class req_search_player_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_search_player_out req_search_player_out = Net.ProtoBuf_Deserialize<req_search_player_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
