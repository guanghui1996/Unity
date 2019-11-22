// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-22 22:32:20
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCommand : Command {
    public override void execute(GameObject gameObject)
    {
        MoveLeft(gameObject);
    }

    private void MoveLeft(GameObject gameObject) {
        gameObject.transform.Translate(Vector3.left * Time.deltaTime * 10);
    }
}
