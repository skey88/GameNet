using com.sporger.server.proto.model;
using Stars;
class notify_restore_mp_ordinary_box_stand_pos_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_restore_mp_ordinary_box_stand_pos_out notify_restore_mp_ordinary_box_stand_pos_out = Net.ProtoBuf_Deserialize<notify_restore_mp_ordinary_box_stand_pos_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
