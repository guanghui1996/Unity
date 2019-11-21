// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 23:16:48
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 指挥者
/// </summary>
public class Director {

    public void Construct(Builder builder)
    {
        builder.BuilderMethodA();
    }
}
