// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-22 22:30:52
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command {

    public virtual void execute(GameObject gameObject) {
        Stay(gameObject);
    }

    private void Stay(GameObject gameObject) {
        gameObject.transform.Translate(Vector3.zero);
    }
}
