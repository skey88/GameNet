using com.sporger.server.proto.model;
using Stars;
class req_equip_start_up_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_equip_start_up_out req_equip_start_up_out = Net.ProtoBuf_Deserialize<req_equip_start_up_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
