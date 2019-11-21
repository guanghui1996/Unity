// ========================================================
// 描述：工厂方法模式抽象产品的具体产品实现-UI资源管理器
// 作者：HUI 
// 创建时间：2019-11-19 21:20:38
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResourceManager : ResourceManager {
    public override void LoadAsset(string name)
    {
        Debug.Log("加载UI文件");
    }

    public override void LoadConfig(string path)
    {
        Debug.Log("加载UI相关的配置文件");
    }

    public override void UnLoadResource(bool status)
    {
        Debug.Log("卸载加载的UI文件");
    }

}
