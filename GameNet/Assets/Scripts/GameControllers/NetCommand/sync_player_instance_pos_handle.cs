using com.sporger.server.proto.model;
using Stars;
class sync_player_instance_pos_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //sync_player_instance_pos_out sync_player_instance_pos_out = Net.ProtoBuf_Deserialize<sync_player_instance_pos_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
