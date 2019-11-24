// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-24 13:44:25
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsSceneName {

    private static InsSceneName _insSceneName;

    private string nextSceneName = "";

    public static InsSceneName Instance() {
        //lock (_insSceneName) {
            if (_insSceneName == null)
            {
                _insSceneName = new InsSceneName();
            }
        //}
        return _insSceneName;
    }
    public string NextSceneName
    {
        get
        {
            return nextSceneName;
        }

        set
        {
            nextSceneName = value;
        }
    }
}
