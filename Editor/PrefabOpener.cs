using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabOpener : EditorWindow
{
    [MenuItem("Window/Custom Windows/Prefab Opener")]
    public static void ShowWindow()
    {
        GetWindow<PrefabOpener>("Prefab Opener");
    }

    private void OnGUI()
    { 
        if (GUILayout.Button("Open prefab"))
        {
            // GameObject obj = Selection.activeObject as GameObject;
            Object obj = AssetDatabase.LoadAssetAtPath<Object>("Assets/Resources/PlatformChunks/Level 1.prefab");
            AssetDatabase.OpenAsset(obj);
        }
    }
}
