using com.sporger.server.proto.model;
using Stars;
class req_draw_reward_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_draw_reward_out req_draw_reward_out = Net.ProtoBuf_Deserialize<req_draw_reward_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
