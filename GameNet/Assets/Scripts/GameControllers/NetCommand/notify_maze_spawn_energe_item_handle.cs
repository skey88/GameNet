using com.sporger.server.proto.model;
using Stars;
class notify_maze_spawn_energe_item_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_maze_spawn_energe_item_out notify_maze_spawn_energe_item_out = Net.ProtoBuf_Deserialize<notify_maze_spawn_energe_item_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
