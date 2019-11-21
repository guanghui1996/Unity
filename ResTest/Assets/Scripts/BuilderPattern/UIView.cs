// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 23:11:20
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 产品父类
/// </summary>
public class UIView {

    protected Text mText;
    protected Text mBtnText;
    protected Image mImage;

    public void Init(Transform transform)
    {
        mText = Instantiate(transform, "UIView/MyText").GetComponent<Text>();
        Button button = Instantiate(transform, "UIView/Button").GetComponent<Button>();
        mBtnText = transform.Find("Button(Clone)/Text").GetComponent<Text>();
        mImage = Instantiate(transform, "UIView/Image").GetComponent<Image>();
    }

    protected GameObject Load(string path)
    {
        return Resources.Load<GameObject>(path);
    }

    protected GameObject Instantiate(Transform parent, string path)
    {
        GameObject go = GameObject.Instantiate(Load(path) as GameObject);
        GameObject goNew = GameObject.Find("");

        go.transform.SetParent(parent, false);
        //go.transform.localScale = Vector3.one; 
        //go.transform.position = go.transform.position;
        return go;
    }
}
