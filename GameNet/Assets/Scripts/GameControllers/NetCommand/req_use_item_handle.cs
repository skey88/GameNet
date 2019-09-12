using com.sporger.server.proto.model;
using Stars;
class req_use_item_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_use_item_out req_use_item_out = Net.ProtoBuf_Deserialize<req_use_item_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
