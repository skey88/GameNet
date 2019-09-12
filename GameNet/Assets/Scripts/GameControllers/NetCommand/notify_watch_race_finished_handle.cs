using com.sporger.server.proto.model;
using Stars;
class notify_watch_race_finished_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_watch_race_finished_out notify_watch_race_finished_out = Net.ProtoBuf_Deserialize<notify_watch_race_finished_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
