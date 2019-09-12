using com.sporger.server.proto.model;
using Stars;
class character_attribute_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //character_attribute_out character_attribute_out = Net.ProtoBuf_Deserialize<character_attribute_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
