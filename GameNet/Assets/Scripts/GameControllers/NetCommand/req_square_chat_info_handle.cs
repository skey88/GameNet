﻿using com.sporger.server.proto.model;
using Stars;
class req_square_chat_info_handle : MessageBase
{
    protected override int MsgExcute(MessageData msgData)
    {
        //req_square_chat_info_out req_square_chat_info_out = Net.ProtoBuf_Deserialize<req_square_chat_info_out>(msgData._eventData);
        return msgData._errorCode;
    }
}
