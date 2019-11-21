// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-19 23:17:22
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderTest : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 120, 50), "按钮1"))
        {
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();

            b1.Init(this.transform);

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();
        }

        if (GUI.Button(new Rect(100, 200, 120, 50), "按钮2"))
        {

            Director director = new Director();
            Builder b2 = new ConcreteBuilder2();

            b2.Init(this.transform);

            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();
        }
    }
}
