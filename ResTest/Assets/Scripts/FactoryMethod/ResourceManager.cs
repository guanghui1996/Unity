// ========================================================
// 描述：工厂方法模式的抽象产品类，由具体产品类继承实现
// 作者：HUI 
// 创建时间：2019-11-19 21:15:10
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceManager {
    public abstract void LoadConfig(string path);
    public abstract void LoadAsset(string name);
    public abstract void UnLoadResource(bool status);
}
