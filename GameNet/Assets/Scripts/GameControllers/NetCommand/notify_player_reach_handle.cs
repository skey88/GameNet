using com.sporger.server.proto.model;
using Stars;
class notify_player_reach_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_player_reach_out notify_player_reach_out = Net.ProtoBuf_Deserialize<notify_player_reach_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
