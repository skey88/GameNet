using com.sporger.server.proto.model;
using Stars;
class heartbeat_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //heartbeat_out heartbeat_out = Net.ProtoBuf_Deserialize<heartbeat_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
