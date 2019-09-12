using com.sporger.server.proto.model;
using Stars;
class req_enter_square_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_enter_square_out req_enter_square_out = Net.ProtoBuf_Deserialize<req_enter_square_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
