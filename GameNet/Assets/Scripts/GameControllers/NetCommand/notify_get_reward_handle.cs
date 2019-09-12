using com.sporger.server.proto.model;
using Stars;
class notify_get_reward_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_get_reward_out notify_get_reward_out = Net.ProtoBuf_Deserialize<notify_get_reward_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
