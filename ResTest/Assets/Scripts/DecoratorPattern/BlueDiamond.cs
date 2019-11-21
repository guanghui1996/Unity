// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 22:03:40
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDiamond : Decorator {

    public BlueDiamond(Weapon weapon) : base(weapon) {

    }

    private void Frozen() {
        Debug.Log("冰冻3s...");
    }

    public override void Attack()
    {
        base.Attack();
        Frozen();
    }
}
