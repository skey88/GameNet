using com.sporger.server.proto.model;
using Stars;
class req_friends_relation_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_friends_relation_out req_friends_relation_out = Net.ProtoBuf_Deserialize<req_friends_relation_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
