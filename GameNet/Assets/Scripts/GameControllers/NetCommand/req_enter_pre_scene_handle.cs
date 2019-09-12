using com.sporger.server.proto.model;
using Stars;
class req_enter_pre_scene_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_enter_pre_scene_out req_enter_pre_scene_out = Net.ProtoBuf_Deserialize<req_enter_pre_scene_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
