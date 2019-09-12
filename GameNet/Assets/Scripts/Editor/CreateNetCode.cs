using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.IO;

public class CreateNetCode  {
    [MenuItem("GameTools/CreateNetCode")]
    static void CreateObservers()
    {
        Type t = typeof(com.sporger.server.proto.model.MessageType);
        FieldInfo[] fieldInfos = t.GetFields();

        string s = 
@"using com.sporger.server.proto.model;

namespace Stars
{
    public class NetObserver
    {
        public static void addObservers(Net net)
        {
            Game game = Game.Get();
";
        
        for(int i = 1;i < fieldInfos.Length;i++)
        {
            string name = fieldInfos[i].Name;
            string commandClassName = name.ToLower() + "_handle";
            string observer = @"            game.RegisterCommand(MessageType." +
                name + @".ToString(), () => new " + commandClassName + "());\r\n";
            s = s + observer;
            string commandClassPath = Application.dataPath + "/Scripts/GameControllers/NetCommand";


            if(!File.Exists(commandClassPath + "/" + commandClassName + ".cs"))
            {
                string commandDataClass = name.ToLower() + "_out";

                string commandClassContent =
                string.Format(
                    @"using com.sporger.server.proto.model;
using Stars;
class {0} : MessageBase
{{
    protected override int MsgExcute(MessageData msgData)
    {{
        //{1} {2} = Net.ProtoBuf_Deserialize<{3}>(msgData._eventData);
        return msgData._errorCode;
    }}
}}", commandClassName, commandDataClass, commandDataClass, commandDataClass);

                Stars.RG_Utils.CreateFile(commandClassPath, commandClassName + ".cs", commandClassContent);

            }
        }

        s += 
@"        }
    }
}";
        Stars.RG_Utils.CreateFile(Application.dataPath + "/Scripts/Net/", "NetObserver.cs", s);
        AssetDatabase.Refresh();
    }


}
