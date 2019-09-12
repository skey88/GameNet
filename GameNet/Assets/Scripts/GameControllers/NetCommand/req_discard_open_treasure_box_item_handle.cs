using com.sporger.server.proto.model;
using Stars;
class req_discard_open_treasure_box_item_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_discard_open_treasure_box_item_out req_discard_open_treasure_box_item_out = Net.ProtoBuf_Deserialize<req_discard_open_treasure_box_item_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
