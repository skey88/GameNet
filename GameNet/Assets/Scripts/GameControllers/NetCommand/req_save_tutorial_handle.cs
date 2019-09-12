using com.sporger.server.proto.model;
using Stars;
class req_save_tutorial_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_save_tutorial_out req_save_tutorial_out = Net.ProtoBuf_Deserialize<req_save_tutorial_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
