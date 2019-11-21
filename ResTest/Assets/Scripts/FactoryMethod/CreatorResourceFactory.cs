// ========================================================
// 描述：简单工厂模式的抽象工厂，由具体工厂类继承实现
// 作者：HUI 
// 创建时间：2019-11-19 21:18:11
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatorResourceFactory {

    public abstract ResourceManager CreatorFactory();
}
