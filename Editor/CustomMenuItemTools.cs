using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CustomMenuItemTools
{
    [MenuItem("Custom Tools/Delete Persistence", priority = 0)]
    static void DeletPresistance()
    {
        Directory.Delete(Application.persistentDataPath, true);
    }

    [MenuItem("Custom Tools/Persistence Folder")]
    static void PersistenceProjectFolder()
    {
        System.Diagnostics.Process.Start("explorer.exe", Application.persistentDataPath.Replace('/', '\\'));
    }

    [MenuItem("Custom Tools/Root Folder")]
    static void RootProjectFolder()
    {
        string dataPath = Application.dataPath;

        // Get rid of /Assets in the end of the path
        // Example "E:/Unity Projects/ReferenceChecker/Assets" normal path
        dataPath = dataPath.Substring(0, dataPath.LastIndexOf("/"));

        System.Diagnostics.Process.Start("explorer.exe", dataPath.Replace('/', '\\'));
    }

    [MenuItem("Custom Tools/Check References %UP")]
    private static void CheckReferences()
    {
        MonoBehaviour[] sceneActive = GameObject.FindObjectsOfType<MonoBehaviour>();

        foreach (MonoBehaviour mono in sceneActive)
        {
            Type monoType = mono.GetType();

            FieldInfo[] objectFields = monoType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            for (int i = 0; i < objectFields.Length; i++)
            {
                NotNullable attribute = objectFields[i].GetCustomAttribute<NotNullable>();

                if (attribute != null)
                {
                    if (objectFields[i].GetValue(mono) == null)
                    {
                        Debug.Log($"GameObject ( {mono.gameObject.name} ) has null reference field ( {objectFields[i].Name} )");
                    }
                }
            }
        }
    }
}
