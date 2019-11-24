// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-24 13:58:03
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSimpleScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            InsSceneName.Instance().NextSceneName = "BigScene";
            Debug.Log(InsSceneName.Instance().NextSceneName);
            StartCoroutine("LoadScene");
        }
    }

    IEnumerator LoadScene()
    {
        SceneManager.LoadScene("SimpleScene");
        yield return null;
    }
}
