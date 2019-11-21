// ========================================================
// 描述：工厂模式客户端测试脚本
// 作者：HUI 
// 创建时间：2019-11-19 21:34:05
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceFactoryMethodClient : MonoBehaviour {

    CreatorResourceFactory audioFactory;
    CreatorResourceFactory uiFactory;

    AudioResourceManager audioManager;
    UIResourceManager uiManager;

	// Use this for initialization
	void Start () {
        audioFactory = new AudioResourceManagerFactory();
        uiFactory = new UIResourceManagerFactory();
	}

    private void OnGUI()
    {
        if (GUILayout.Button("音乐管理器")) {
            audioManager = audioFactory.CreatorFactory() as AudioResourceManager;
            audioManager.LoadConfig("http:.....");
            audioManager.LoadAsset("声音");
            audioManager.UnLoadResource(false);
        }
        if (GUILayout.Button("界面管理器"))
        {
            uiManager = uiFactory.CreatorFactory() as UIResourceManager;
            uiManager.LoadConfig("http:.....");
            uiManager.LoadAsset("UI...");
            uiManager.UnLoadResource(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
