using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectPinger : EditorWindow
{

    [MenuItem("Window/Custom Windows/Object Pinger")]
    public static void ShowWindow()
    {
        GetWindow<ObjectPinger>("Object Pinger");
    }

    private void OnGUI()
    {

        if (GUILayout.Button("Name of Object"))
        {
            string path = "PathToYourAsset";

            if (path[path.Length - 1] == '/')
                path = path.Substring(0, path.Length - 1);

            Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(Object));

            Selection.activeObject = obj;
            EditorGUIUtility.PingObject(obj);

        }
    }

}
