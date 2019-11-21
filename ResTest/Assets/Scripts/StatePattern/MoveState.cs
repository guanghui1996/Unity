// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-20 23:06:54
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveState {

    public abstract void Handle(Controller ctrl);
}
