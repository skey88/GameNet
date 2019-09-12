using com.sporger.server.proto.model;
using Stars;
class notify_rainbowrun_change_track_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_rainbowrun_change_track_out notify_rainbowrun_change_track_out = Net.ProtoBuf_Deserialize<notify_rainbowrun_change_track_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
