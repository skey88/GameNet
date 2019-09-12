using com.sporger.server.proto.model;
using Stars;
class req_enter_finish_point_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_enter_finish_point_out req_enter_finish_point_out = Net.ProtoBuf_Deserialize<req_enter_finish_point_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
