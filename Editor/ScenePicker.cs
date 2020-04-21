using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ScenePicker : EditorWindow
{

    [MenuItem("Window/Custom Windows/Scene Picker")]
    public static void ShowWindow()
    {
        GetWindow<ScenePicker>("Scene Picker");
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Name your Scene"))
        {
            //Load Splash Scene
            EditorSceneManager.OpenScene("PathToYourScene.unity");
        }



    }
}
