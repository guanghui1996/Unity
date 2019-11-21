using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Template {

    protected Text mBtnText;
    protected Text mText;
    protected Image mImage;
    protected Action Callback;
    protected Button button;

    public Template() { }

    protected void Init(Transform transform) {
        mBtnText = transform.Find("Button/Text").GetComponent<Text>();
        mText = transform.Find("Text").GetComponent<Text>();
        mImage = transform.Find("Image").GetComponent<Image>();

        button = transform.Find("Button").GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log("点击了按钮：" + mBtnText.text);
        if (Callback != null)
            Callback();
    }

    protected virtual void Method1() { }

    public void TemplateMethod(Transform transform) {
        Init(transform);
        Method1();
    }
}
