// ========================================================
// 描述：具体工厂类-UI资源工厂类
// 作者：HUI 
// 创建时间：2019-11-19 21:27:56
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResourceManagerFactory : CreatorResourceFactory
{
    public override ResourceManager CreatorFactory()
    {
        return new UIResourceManager();
    }
}
