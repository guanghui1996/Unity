// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-20 23:05:05
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{

    private MoveState moveState;
    public MoveState MoveState
    {
        get { return moveState; }
        set { moveState = value; }
    }

    private GameObject obj;
    public GameObject Obj
    {
        get { return obj; }
        set { obj = value; }
    }

    public Controller(GameObject obj, MoveState moveState)
    {
        this.obj = obj;
        this.moveState = moveState;
    }

    public void Handle()
    {
        moveState.Handle(this);
    }
}
