﻿using com.sporger.server.proto.model;
using Stars;
class req_character_status_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_character_status_out req_character_status_out = Net.ProtoBuf_Deserialize<req_character_status_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
