using com.sporger.server.proto.model;
using Stars;
class req_open_treasure_box_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_open_treasure_box_out req_open_treasure_box_out = Net.ProtoBuf_Deserialize<req_open_treasure_box_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
