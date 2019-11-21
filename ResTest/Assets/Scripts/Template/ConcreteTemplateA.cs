using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteTemplateA : Template {

    protected override void Method1()
    {
        base.Method1();
        mText.text = "模板方法A";
        mBtnText.text = "模板方法A按钮";
        mImage.color = Color.green;

        Callback = OnClikeA;
    }

    private void OnClikeA()
    {
        Debug.Log("模板方法A的按钮事件");
    }
}
