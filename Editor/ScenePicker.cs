using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ScenePicker : EditorWindow
{

    private List<string> _filePaths = new List<string>();
    private string ABSOLUTE_PROJECT_SCENE_PATH => Application.dataPath + "/Scenes/";
    private string SCENE_DIRECTORY_PATH => "Assets/Scenes/";

    Dictionary<string, string> _sceneDictionary = new Dictionary<string, string>();

    private void Awake()
    {
        LoadAllScenePaths();
    }

    [MenuItem("Window/Custom Windows/Scene Picker")]
    public static void ShowWindow()
    {
        GetWindow<ScenePicker>("Scene Picker");
    }

    private void OnGUI()
    {
        GUI.color = Color.magenta;
        if (GUILayout.Button("Refresh List"))
        {
            LoadAllScenePaths();
        }
        GUI.color = Color.white;

        foreach (KeyValuePair<string, string> scene in _sceneDictionary)
        {
            if (GUILayout.Button(scene.Key))
            {
                EditorSceneManager.OpenScene(scene.Value);
            }
        }
    }

    private void LoadAllScenePaths()
    {
        List<string> _scenePaths = new List<string>();
        List<string> _sceneNames = new List<string>();
        
        foreach (string filePath in Directory.GetFiles(ABSOLUTE_PROJECT_SCENE_PATH))
        {
            if(!filePath.Contains(".meta"))
            {
                string sceneNameWithExtension = string.Empty;

                int sceneNameStartIndex = 0;

                // Get name of the scenes
                for (int i = filePath.Length-1; i >= 0; i--)
                {
                    if(filePath[i] == '/')
                    {
                        // We want not this characters ('/[thisIndex]') index but the previous.
                        sceneNameStartIndex = i+1;
                        break;
                    }
                }

                sceneNameWithExtension = filePath.Substring(sceneNameStartIndex, filePath.Length - sceneNameStartIndex);

                _scenePaths.Add(SCENE_DIRECTORY_PATH + sceneNameWithExtension);

                // Parse the string with name and extension to get just the name of the scene.
                string sceneName = sceneNameWithExtension.Split('.')[0];

                _sceneNames.Add( sceneName );
            }
        }

        if(_sceneNames.Count != _scenePaths.Count)
        {
            Debug.LogError($"{_sceneNames.Count} --- {_scenePaths.Count}");
            return;
        }

        Dictionary<string, string> sceneDictionary = new Dictionary<string, string>();

        for (int i = 0; i < _sceneNames.Count; i++)
        {
            sceneDictionary.Add(_sceneNames[i], _scenePaths[i]);
        }

        _sceneDictionary = sceneDictionary;
    }
}
