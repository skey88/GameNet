using com.sporger.server.proto.model;
using Stars;
class login_validate_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //login_validate_out login_validate_out = Net.ProtoBuf_Deserialize<login_validate_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
