using com.sporger.server.proto.model;
using Stars;
class req_select_scene_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_select_scene_out req_select_scene_out = Net.ProtoBuf_Deserialize<req_select_scene_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
