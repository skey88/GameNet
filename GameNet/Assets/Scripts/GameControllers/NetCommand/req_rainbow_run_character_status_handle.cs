using com.sporger.server.proto.model;
using Stars;
class req_rainbow_run_character_status_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_rainbow_run_character_status_out req_rainbow_run_character_status_out = Net.ProtoBuf_Deserialize<req_rainbow_run_character_status_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
