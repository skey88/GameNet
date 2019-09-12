using com.sporger.server.proto.model;
using Stars;
class notify_open_mp_ordinary_box_stand_pos_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_open_mp_ordinary_box_stand_pos_out notify_open_mp_ordinary_box_stand_pos_out = Net.ProtoBuf_Deserialize<notify_open_mp_ordinary_box_stand_pos_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
