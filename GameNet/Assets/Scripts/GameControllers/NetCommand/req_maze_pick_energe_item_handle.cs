using com.sporger.server.proto.model;
using Stars;
class req_maze_pick_energe_item_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_maze_pick_energe_item_out req_maze_pick_energe_item_out = Net.ProtoBuf_Deserialize<req_maze_pick_energe_item_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
