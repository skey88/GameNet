using com.sporger.server.proto.model;
using Stars;
class notify_box_and_item_list_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_box_and_item_list_out notify_box_and_item_list_out = Net.ProtoBuf_Deserialize<notify_box_and_item_list_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
