using com.sporger.server.proto.model;
using Stars;
class location_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //location_out location_out = Net.ProtoBuf_Deserialize<location_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
