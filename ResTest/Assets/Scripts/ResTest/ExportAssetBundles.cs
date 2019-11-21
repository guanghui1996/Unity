using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExportAssetBundles : MonoBehaviour {

    [MenuItem("Assets/Build AssetBundle From Selection - Track dependencies")]
    static void ExportResources() {
        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");
        if (path.Length != 0) {
            //Selection.GetFiltered返回按类型和模式筛选的当前选择。
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            //BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
            bool res = BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows64);
            Selection.objects = selection;
            if (res)
            {
                Debug.Log("资源包生成成功");
            }
            else {
                Debug.Log("资源包生成失败");
            }

        }
    }

    [MenuItem("Assets/Build AssetBundle Form Selection - No dependency tracking")]
    static void ExportResourceNoTrack() {
        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");
        if (path.Length != 0) {
            bool res = BuildPipeline.BuildAssetBundle(Selection.activeObject, Selection.objects, path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
            if (res)
            {
                Debug.Log("资源包生成成功");
            }
            else
            {
                Debug.Log("资源包生成失败");
            }
        }
    }

}
