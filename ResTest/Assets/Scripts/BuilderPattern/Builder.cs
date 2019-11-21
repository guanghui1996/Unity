// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 23:14:28
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 建造者基类
/// </summary>
public abstract class Builder : UIView {

    public abstract void BuilderMethodA();
    /// <summary>
    /// 获取产品
    /// </summary>
    /// <returns></returns>
    public abstract Product GetResult();
}
