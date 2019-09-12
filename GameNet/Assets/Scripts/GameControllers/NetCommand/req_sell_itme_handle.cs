using com.sporger.server.proto.model;
using Stars;
class req_sell_itme_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_sell_itme_out req_sell_itme_out = Net.ProtoBuf_Deserialize<req_sell_itme_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
