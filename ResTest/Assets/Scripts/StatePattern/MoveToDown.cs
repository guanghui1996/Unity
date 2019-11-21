// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-20 23:08:00
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDown : MoveState {

    public override void Handle(Controller ctrl)
    {
        GameObject obj = ctrl.Obj;

        if (Camera.main.WorldToViewportPoint(obj.transform.position).y > 0)
        {
            obj.transform.Translate(Vector3.down * Time.deltaTime * 15);
        }
        else
        {
            ctrl.MoveState = new MoveToUp();
        }
    }
}
