using com.sporger.server.proto.model;
using Stars;
class req_enter_map_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_enter_map_out req_enter_map_out = Net.ProtoBuf_Deserialize<req_enter_map_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
