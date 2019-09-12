using com.sporger.server.proto.model;
using Stars;
class req_uninstall_equip_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_uninstall_equip_out req_uninstall_equip_out = Net.ProtoBuf_Deserialize<req_uninstall_equip_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
