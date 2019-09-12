using com.sporger.server.proto.model;
using Stars;
class req_player_list_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_player_list_out req_player_list_out = Net.ProtoBuf_Deserialize<req_player_list_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
