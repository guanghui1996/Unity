// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 22:01:41
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDiamond : Decorator {
    public RedDiamond(Weapon weapon) : base(weapon) {

    }

    private void Dizziness() {
        Debug.Log("眩晕2s");
    }

    public override void Attack()
    {
        base.Attack();
        Dizziness();
    }
}
