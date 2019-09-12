using com.sporger.server.proto.model;
using Stars;
class req_gm_command_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_gm_command_out req_gm_command_out = Net.ProtoBuf_Deserialize<req_gm_command_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
