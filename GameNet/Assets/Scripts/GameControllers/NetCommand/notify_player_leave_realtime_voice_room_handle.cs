using com.sporger.server.proto.model;
using Stars;
class notify_player_leave_realtime_voice_room_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_player_leave_realtime_voice_room_out notify_player_leave_realtime_voice_room_out = Net.ProtoBuf_Deserialize<notify_player_leave_realtime_voice_room_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
