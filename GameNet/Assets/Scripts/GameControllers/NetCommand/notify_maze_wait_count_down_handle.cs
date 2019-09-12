using com.sporger.server.proto.model;
using Stars;
class notify_maze_wait_count_down_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_maze_wait_count_down_out notify_maze_wait_count_down_out = Net.ProtoBuf_Deserialize<notify_maze_wait_count_down_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
