using com.sporger.server.proto.model;
using Stars;
class notify_maze_character_energe_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //notify_maze_character_energe_out notify_maze_character_energe_out = Net.ProtoBuf_Deserialize<notify_maze_character_energe_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
