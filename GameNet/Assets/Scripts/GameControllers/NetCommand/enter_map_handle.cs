using com.sporger.server.proto.model;
using Stars;
class enter_map_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //enter_map_out enter_map_out = Net.ProtoBuf_Deserialize<enter_map_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
