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

}
