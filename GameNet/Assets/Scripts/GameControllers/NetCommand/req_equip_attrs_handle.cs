using com.sporger.server.proto.model;
using Stars;
class req_equip_attrs_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_equip_attrs_out req_equip_attrs_out = Net.ProtoBuf_Deserialize<req_equip_attrs_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
