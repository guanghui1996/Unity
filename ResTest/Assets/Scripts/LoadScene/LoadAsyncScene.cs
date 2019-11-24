// ========================================================
// 描述：AsyncOperation操作只能加载到90%，之后的10%不在加载
// 可能由于场景过于简单 async.progress直接就达到了90% 
// 所以使slider.value最大值为0.89 text上面的文字就变成了slider.value * 100 / 89 *100
// 为了能看到加载效果  使用Slider.value值由插值来计算不直接赋值
// 也是因为上面那个原因 text的文字变换也有slider.value来判断
//
// 加载操作可以放在协程里  也可以放在Update中  
// 在协程中使要注意在while循环里返回值 在Update中时协程要返回 async ??
// 作者：HUI 
// 创建时间：2019-11-24 13:26:35
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadAsyncScene : MonoBehaviour {

    /// <summary>
    /// 文本进度条
    /// </summary>
    private Text progress;
    /// <summary>
    /// 进度值
    /// </summary>
    private float progressValue;
    private Slider slider;
    private string nextSceneName;
    private AsyncOperation async = null;

    public float loadingSpeed;


	// Use this for initialization
	void Start () {
        nextSceneName = InsSceneName.Instance().NextSceneName;
        progress = GetComponent<Text>();
        slider = FindObjectOfType<Slider>();
        Debug.Log("马上进入加载方法");
        
        StartCoroutine("LoadScene");
	}

    private void Update()
    {
        //if (async == null)
        //    return;
        //if (async.progress < 0.95f)
        //    progressValue = async.progress;
        //else
        //    progressValue = 1.0f;
        //slider.value = progressValue;
        //slider.value = Mathf.Lerp(slider.value, progressValue, Time.deltaTime * loadingSpeed);
        //progress.text = ((int)(slider.value * 100)).ToString() + "%";
        //if (progressValue >= 0.9f)
        //{
        //    progress.text = "press anything";
        //    if (Input.anyKeyDown)
        //    {
        //        async.allowSceneActivation = true;
        //    }
        //}
    }

    IEnumerator LoadScene() {
        Debug.Log("进入加载方法");
        async = SceneManager.LoadSceneAsync(nextSceneName);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            if (async.progress < 0.95f)
                progressValue = async.progress;
            else
                progressValue = 1.0f;
            slider.value = Mathf.Lerp(slider.value, progressValue, Time.deltaTime * loadingSpeed);
            progress.text = ((int)(slider.value * 100 * 100 / 89)).ToString() + "%";
            if (slider.value >= 0.89f) //progressValue >= 0.9f)
            {
                //if(slider.value >= 0.9f)
                progress.text = "press anything";
                if (Input.anyKeyDown)
                {
                    slider.value = 0.89f;
                    async.allowSceneActivation = true;
                }
            }
            yield return null;
        }
        //yield return async;
    }
}
