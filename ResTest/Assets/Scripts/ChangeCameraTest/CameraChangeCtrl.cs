// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-22 23:06:27
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeCtrl : MonoBehaviour {

    /// <summary>
    /// 主摄像机
    /// </summary>
    private Camera mainCamera;
    /// <summary>
    /// 辅助摄像机
    /// </summary>
    private Camera aidCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        aidCamera = GameObject.Find("AidCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.M))
        {
            mainCamera.enabled = true;
            aidCamera.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            aidCamera.enabled = true;
            mainCamera.enabled = false;
        }
	}
}
