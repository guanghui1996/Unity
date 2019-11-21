// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 21:57:35
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 装饰者基类
/// </summary>
public abstract class Decorator : Weapon {

    private Weapon m_weapon;

    public Decorator(Weapon weapon) {
        this.m_weapon = weapon;
    }

    /// <summary>
    /// 武器攻击
    /// 
    /// </summary>
    public override void Attack()
    {
        m_weapon.Attack();
    }
}
