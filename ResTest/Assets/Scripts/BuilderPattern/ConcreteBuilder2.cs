// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 23:15:54
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实际建造者2
/// </summary>
public class ConcreteBuilder2 : Builder {

    private Product product = new Product();
    public override void BuilderMethodA()
    {
        mText.text = "建造者B";
        mBtnText.text = "建造者B按钮";
        mImage.color = Color.red;
    }

    public override Product GetResult()
    {
        return product;
    }
}
