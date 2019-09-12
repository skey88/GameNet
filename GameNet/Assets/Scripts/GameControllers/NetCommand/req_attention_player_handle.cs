using com.sporger.server.proto.model;
using Stars;
class req_attention_player_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_attention_player_out req_attention_player_out = Net.ProtoBuf_Deserialize<req_attention_player_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
