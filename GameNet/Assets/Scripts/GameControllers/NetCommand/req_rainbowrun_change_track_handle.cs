using com.sporger.server.proto.model;
using Stars;
class req_rainbowrun_change_track_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_rainbowrun_change_track_out req_rainbowrun_change_track_out = Net.ProtoBuf_Deserialize<req_rainbowrun_change_track_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
