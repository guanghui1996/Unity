// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 22:00:16
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 剑类
/// </summary>
public class Sword : Weapon {

    public override void Attack()
    {
        Debug.Log("剑普通攻击!");
    }
}
