using PureMVC.Patterns.Command;
using PureMVC.Interfaces;
using com.sporger.server.proto.model;
using System;
using Stars;
public class MessageData : IDisposable
{
    public MessageType _eventType;
    public byte[] _eventData;
    public ushort _errorCode;
    public ulong _msgIndex;

    public void Dispose()
    {
        _eventData = null;
    }
}

public struct ErrorMsgInfo
{
    public ulong _msgIndex;
    public ushort _errorCode;
}

public abstract class MessageBase : SimpleCommand
{
    const int ErrorCodeNUM = 600000;
    public override void Execute(INotification notification)
    {
        sEvent_NetMessageData Event_NetMessageData = (sEvent_NetMessageData)notification.Body;
        using (MessageData msgData = new MessageData())
        {
            msgData._eventType = Event_NetMessageData._eventType;
            msgData._eventData = Event_NetMessageData._eventData;
            msgData._errorCode = Event_NetMessageData._errorcode;
            msgData._msgIndex = Event_NetMessageData._msgIndex;
            if (Event_NetMessageData._errorcode == 0)
            {
                MsgExcute(msgData);
            }
            else
            {
                ErrorMsgInfo info = new ErrorMsgInfo()
                {
                    _msgIndex = Event_NetMessageData._msgIndex,
                    _errorCode = Event_NetMessageData._errorcode
                };
                NotifyError(info);
                TyLogger.Log(msgData._eventType + " errorcode = " + msgData._errorCode);
            }
        }
    }

    protected abstract int MsgExcute(MessageData msgData);
    protected virtual void NotifyError(ErrorMsgInfo info)
    {
        //string errormsg = RG_Utils.getLanguageString((uint)(ErrorCodeNUM + info._errorCode));
        //sSendNotification(RGGameGlobalEventType.SHOW_FLOAT_TEXT, errormsg);
    }
}
