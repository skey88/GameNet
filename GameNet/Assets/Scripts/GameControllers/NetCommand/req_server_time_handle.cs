using com.sporger.server.proto.model;
using Stars;
class req_server_time_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_server_time_out req_server_time_out = Net.ProtoBuf_Deserialize<req_server_time_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
