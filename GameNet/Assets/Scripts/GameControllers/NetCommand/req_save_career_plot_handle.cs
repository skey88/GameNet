using com.sporger.server.proto.model;
using Stars;
class req_save_career_plot_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_save_career_plot_out req_save_career_plot_out = Net.ProtoBuf_Deserialize<req_save_career_plot_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
