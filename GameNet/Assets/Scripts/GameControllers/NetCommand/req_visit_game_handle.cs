using com.sporger.server.proto.model;
using Stars;
class req_visit_game_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_visit_game_out req_visit_game_out = Net.ProtoBuf_Deserialize<req_visit_game_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
