// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 23:13:46
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实际产品类
/// </summary>
public class Product : MonoBehaviour {

    List<UIView> parts = new List<UIView>();

    /// <summary>
    /// 为产品添加组件
    /// </summary>
    /// <param name="go"></param>
    public void Add(UIView go)
    {
        if (go is ConcreteBuilder1)
            parts.Add(go as ConcreteBuilder1);
        if (go is ConcreteBuilder2)
            parts.Add(go as ConcreteBuilder2);
    }

    public void Show()
    {
        foreach (UIView go in parts)
        {
            if (go is ConcreteBuilder1)
            {
                ConcreteBuilder1 b1 = go as ConcreteBuilder1;
                b1.BuilderMethodA();
            }
            if (go is ConcreteBuilder2)
            {
                (go as ConcreteBuilder2).BuilderMethodA();
            }
        }
    }
}
