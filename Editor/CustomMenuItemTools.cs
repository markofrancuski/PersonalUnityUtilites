using UnityEditor;
using UnityEngine;

public class CustomMenuItemTools
{
    [MenuItem("Custom Tools/Open Persistence Folder")]
    static void ApplicationPersistence()
    {
        System.Diagnostics.Process.Start("explorer.exe", Application.persistentDataPath.Replace('/', '\\'));
    }
}
