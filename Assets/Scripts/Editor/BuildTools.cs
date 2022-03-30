using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

public class BuildTools : Editor
{
#if UNITY_EDITOR

    [MenuItem("Tools/BuildPackage &b")]
    private static void Build()
    {
        var summaryResult = BuildPipeline.BuildPlayer(GetSceneNames(), GetOutFilePath(), EditorUserBuildSettings.activeBuildTarget, BuildOptions.Development).summary.result;
        switch (summaryResult)
        {
            case BuildResult.Succeeded:
                Debug.Log("打包成功!");
                break;
            case BuildResult.Cancelled:
                Debug.LogWarning("打包取消!");
                break;
            case BuildResult.Failed:
                Debug.LogError("打包失败!");
                break;
        }
    }

    private static string GetOutFilePath()
    {
        var outFolderPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "_BuildPack");
        return Path.Combine(outFolderPath, PlayerSettings.productName + ".exe").Replace("\\", "/");
    }

    private static string[] GetSceneNames()
    {
        var names = new List<string>();
        foreach (var e in EditorBuildSettings.scenes)
        {
            if (e is null) continue;
            if (e.enabled) names.Add(e.path);
        }
        return names.ToArray();
    }

#endif
}
