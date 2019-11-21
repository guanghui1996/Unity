//===================================================
//备    注：替换代码注释
//===================================================
using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEditor;

/// <summary>
/// 在资源创建时调用
/// </summary>
public class ScriptCreatInit : UnityEditor.AssetModificationProcessor
{
    private static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        if (!path.EndsWith(".cs")) return;
        string allText = "// ========================================================\r\n"
                         + "// 描述：\r\n"
                         + "// 作者：HUI \r\n"
                         + "// 创建时间：#CreateTime#\r\n"
                         + "// 版 本：1.0\r\n"
                         + "// ========================================================\r\n";
        allText += File.ReadAllText(path);
        allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        File.WriteAllText(path, allText);
    }
}