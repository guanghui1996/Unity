// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-22 22:41:33
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler {

    private Command left;
    private Command right;

    public InputHandler() {
        left = new LeftCommand();
        right = new RightCommand();
    }

    public Command handleInput() {
        if (Input.GetKey(KeyCode.A))
        {
            return left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            return right;
        }
        return new Command();
    }
}
