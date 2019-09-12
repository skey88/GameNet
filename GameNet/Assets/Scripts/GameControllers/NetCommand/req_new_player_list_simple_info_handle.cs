using com.sporger.server.proto.model;
using Stars;
class req_new_player_list_simple_info_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_new_player_list_simple_info_out req_new_player_list_simple_info_out = Net.ProtoBuf_Deserialize<req_new_player_list_simple_info_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
