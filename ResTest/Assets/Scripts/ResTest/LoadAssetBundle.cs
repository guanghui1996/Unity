using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour {

    private MeshRenderer MR = null;

    private IEnumerator Start()
    {
        WWW www = new WWW(@"file:///D:\Unity\ResTest\Assets\AssetsBundles\Asset_Textures.unity3d");

        yield return www;

        Texture Tex = www.assetBundle.LoadAsset("money",typeof(Texture)) as Texture;

        MR = GetComponent<MeshRenderer>();
        MR.material.mainTexture = Tex;
    }
}
