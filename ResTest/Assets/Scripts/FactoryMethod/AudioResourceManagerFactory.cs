// ========================================================
// 描述：具体工厂类-音频资源工厂类
// 作者：HUI 
// 创建时间：2019-11-19 21:30:51
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioResourceManagerFactory : CreatorResourceFactory
{
    public override ResourceManager CreatorFactory()
    {
        return new AudioResourceManager();
    }
}
