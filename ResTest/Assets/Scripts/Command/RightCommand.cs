// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-22 22:35:17
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCommand : Command {

    public override void execute(GameObject gameObject)
    {
        MoveRight(gameObject);
    }

    private void MoveRight(GameObject gameObject) {
        gameObject.transform.Translate(Vector3.right * Time.deltaTime * 10);
    }
}
