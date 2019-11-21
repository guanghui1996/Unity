using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteTemplateB : Template
{

    protected override void Method1()
    {
        base.Method1();
        mText.text = "模板方法B";
        mBtnText.text = "模板方法B按钮";
        mImage.color = Color.yellow;

        Callback = OnClikeA;
    }

    private void OnClikeA()
    {
        Debug.Log("模板方法B的按钮事件");
    }
}
