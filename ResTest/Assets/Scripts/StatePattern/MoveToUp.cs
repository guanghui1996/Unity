// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-20 23:07:26
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToUp : MoveState {

    public override void Handle(Controller ctrl)
    {
        GameObject obj = ctrl.Obj;

        if (Camera.main.WorldToViewportPoint(obj.transform.position).y < 1)
        {
            obj.transform.Translate(Vector3.up * Time.deltaTime * 15);
        }
        else
        {
            ctrl.MoveState = new MoveToDown();
        }
    }
}
