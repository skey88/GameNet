using com.sporger.server.proto.model;
using Stars;
class notify_start_race_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_start_race_out notify_start_race_out = Net.ProtoBuf_Deserialize<notify_start_race_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
