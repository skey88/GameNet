using UnityEngine;
using System.Collections;
using System.Text;
using System;
using ProtoBuf;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using com.sporger.server.proto.model;
using Stars;

public class Client : MonoBehaviour {

    public Transform BtnRoot;

    void Start()
    {
        RegeditControl();
    }
    

    void OnEnable()
    {
        MessageCenter.Instance.AddEventListener(eGameLogicEventType.NoticeInfo, CallBack_PoseEvent);
        MessageCenter.Instance.addObsever(MessageType.LOGIN_VALIDATE, CallBack_ProtoBuff_LoginServer);
        //MessageCenter.Instance.addObsever(MessageType.sc_protobuf_loc, CallBack_Update_Location);
        // MessageCenter.Instance.addObsever(MessageType.sc_binary_login, CallBack_Binary_LoginServer);
    }

    void OnDisable()
    {
        MessageCenter.Instance.RemoveEventListener(eGameLogicEventType.NoticeInfo, CallBack_PoseEvent);
        MessageCenter.Instance.removeObserver(MessageType.LOGIN_VALIDATE, CallBack_ProtoBuff_LoginServer);
        //MessageCenter.Instance.removeObserver(MessageType.sc_protobuf_loc, CallBack_Update_Location);
        //MessageCenter.Instance.removeObserver(MessageType.sc_binary_login, CallBack_Binary_LoginServer);
    }

    void OnApplicationQuit()
    {
        SocketManager.Instance.Close();
    }

    private void RegeditControl()
    {
        BtnRoot.Find("Btn_Connect").GetComponent<Button>().onClick.AddListener(OnButton_Connect);
        BtnRoot.Find("Btn_DisConnect").GetComponent<Button>().onClick.AddListener(OnButton_DisConnect);
        BtnRoot.Find("Btn_PostEvent_NoticeInfo").GetComponent<Button>().onClick.AddListener(OnButton_PostEvent);
        BtnRoot.Find("Btn_Login").GetComponent<Button>().onClick.AddListener(OnButton_ProtoBuff_SendMsg);
        //BtnRoot.FindChild("Btn_SendMsg_Binary").GetComponent<Button>().onClick.AddListener(OnButton_Binary_SendMsg);
    }


    private void OnButton_Connect()
    {
        //SocketManager.Instance.Connect(GameConst.IP, GameConst.Port);
    }

    private void OnButton_DisConnect()
    {
        SocketManager.Instance.Close();
    }

    private void OnButton_PostEvent()
    {
        string _content = "GameLogicEvent";
        MessageCenter.Instance.PostEvent(eGameLogicEventType.NoticeInfo, _content);
    }

    private void OnButton_ProtoBuff_SendMsg()
    {
        //login_validate_in login_validate_in = new login_validate_in();
        //login_validate_in.userId = "sporger";
        //login_validate_in.password = "tiyou2016";
        //SocketManager.Instance.SendMsg(MessageType.LOGIN_VALIDATE, login_validate_in);
    }
    
    private void OnButton_Binary_SendMsg()
    {
        ByteStreamBuff _tmpbuff = new ByteStreamBuff();
        _tmpbuff.Write_UniCodeString("sporger");
        _tmpbuff.Write_UniCodeString("tiyou2016");
        //SocketManager.Instance.SendMsg(MessageType.sc_binary_login, _tmpbuff);
    }

    private void CallBack_PoseEvent(object _eventParam)
    {
        string _content = (string)_eventParam;
        Debug.Log(_content);
    }

    private void CallBack_ProtoBuff_LoginServer(byte[] _msgData)
    {
        //login_validate_out login_validate_out = SocketManager.ProtoBuf_Deserialize<login_validate_out>(_msgData);
        //Debug.Log("login_validate_out " + login_validate_out.result);
        //SceneManager.LoadScene("fr1");


    }

    private void CallBack_Update_Location(byte[] _msgData)
    {

    }

    private void CallBack_Binary_LoginServer(byte[] _msgData)
    {
        ByteStreamBuff _tmpbuff = new ByteStreamBuff(_msgData);
        Debug.Log(_tmpbuff.Read_Int());
        Debug.Log(_tmpbuff.Read_Float());
        Debug.Log(_tmpbuff.Read_UniCodeString());
        Debug.Log(_tmpbuff.Read_UniCodeString());
        _tmpbuff.Close();
        _tmpbuff = null;
    }
}
