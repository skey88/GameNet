﻿using com.sporger.server.proto.model;
using Stars;
class player_goin_instance_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //player_goin_instance_out player_goin_instance_out = Net.ProtoBuf_Deserialize<player_goin_instance_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
