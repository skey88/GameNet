using com.sporger.server.proto.model;
using Stars;
class notify_permite_enter_pre_scene_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_permite_enter_pre_scene_out notify_permite_enter_pre_scene_out = Net.ProtoBuf_Deserialize<notify_permite_enter_pre_scene_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
