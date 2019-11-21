// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 22:05:35
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Weapon sw = new Sword();
        sw.Attack();
        print("----------------------------");

        sw = new RedDiamond(sw);
        sw.Attack();
        print("========================");

        sw = new BlueDiamond(sw);
        sw.Attack();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
