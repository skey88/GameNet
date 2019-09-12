using com.sporger.server.proto.model;
using Stars;
class notify_player_ready_enter_pre_scene_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_player_ready_enter_pre_scene_out notify_player_ready_enter_pre_scene_out = Net.ProtoBuf_Deserialize<notify_player_ready_enter_pre_scene_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
