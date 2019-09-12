using com.sporger.server.proto.model;
using Stars;
class notify_maze_destroy_door_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_maze_destroy_door_out notify_maze_destroy_door_out = Net.ProtoBuf_Deserialize<notify_maze_destroy_door_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
