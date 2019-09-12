using com.sporger.server.proto.model;
using Stars;
class req_wear_equip_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_wear_equip_out req_wear_equip_out = Net.ProtoBuf_Deserialize<req_wear_equip_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
