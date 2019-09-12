using com.sporger.server.proto.model;
using Stars;
class req_maze_destroy_door_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_maze_destroy_door_out req_maze_destroy_door_out = Net.ProtoBuf_Deserialize<req_maze_destroy_door_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
