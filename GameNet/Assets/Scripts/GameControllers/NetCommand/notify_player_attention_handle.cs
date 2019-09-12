using com.sporger.server.proto.model;
using Stars;
class notify_player_attention_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_player_attention_out notify_player_attention_out = Net.ProtoBuf_Deserialize<notify_player_attention_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
