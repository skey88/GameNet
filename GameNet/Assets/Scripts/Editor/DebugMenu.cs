using UnityEngine;
using UnityEditor;
using Stars;
using com.sporger.server.proto.model;

public class DebugMenu 
{
    [MenuItem("GameTools/Debug/UnloadUnusedAssetsImmediate")]
    static void UnloadUnusedMemory()
    {
        EditorUtility.UnloadUnusedAssetsImmediate();
        System.GC.Collect();
    }


    [MenuItem("GameTools/Debug/Time/SetTimeScale:1")]
    static void SetTimeScale1()
    {
        Time.timeScale = 1;
    }

    [MenuItem("GameTools/Debug/Time/SetTimeScale:0.5")]
    static void SetTimeScale05()
    {
        Time.timeScale = 0.5f;
    }

    [MenuItem("GameTools/Debug/Time/SetTimeScale:0.2")]
    static void SetTimeScale02()
    {
        Time.timeScale = 0.2f;
    }

    [MenuItem("GameTools/Debug/Time/SetTimeScale:0.1")]
    static void SetTimeScale01()
    {
        Time.timeScale = 0.1f;
    }    

    [MenuItem("GameTools/Debug/Profiler/BeginLog")]
    static void BeginLog()
    {
        UnityEngine.Profiling.Profiler.logFile = "mylog.log";
        UnityEngine.Profiling.Profiler.enabled = true;
    }

    [MenuItem("GameTools/Debug/Profiler/EndLog")]
    static void EndLog()
    {
        UnityEngine.Profiling.Profiler.enabled = false;
    } 

    [MenuItem("GameTools/Debug/返回登录")]
    static void BackToLogin()
    {
        //RGGameLogic.backToLogin();
    }

    [MenuItem("GameTools/Debug/设置图像质量/最高精度")]
    static void QualitySettingsmasterTextureLimit0()
    {
        QualitySettings.masterTextureLimit = 0;
    }
    [MenuItem("GameTools/Debug/设置图像质量/一半精度")]
    static void QualitySettingsmasterTextureLimit1()
    {
        QualitySettings.masterTextureLimit = 1;
    }

    //[MenuItem("GameTools/Debug/关闭网络")]
    //static void CloseNet()
    //{
    //    if (SocketManager.HaveInstance())
    //    {
    //        SocketManager.Instance.Close();
    //        TyLogger.Log("关闭网络");
    //    }
    //}

    //[MenuItem("GameTools/Debug/副本/设置跑步距离为100米")]
    //static void SetRunDistanceto100()
    //{
    //    if(Net.Get() != null)
    //    {
    //        req_gm_command_in req_gm_command_in = new req_gm_command_in();
    //        req_gm_command_in.gmCommand = "setdis 100";
    //        Net.Get().sendMsg(com.sporger.server.proto.model.MessageType.REQ_GM_COMMAND, req_gm_command_in);
    //    }
    //}
}
