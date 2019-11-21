using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateTest : MonoBehaviour {

    private void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 120, 50), "按钮A")) {
            Template a = new ConcreteTemplateA();
            a.TemplateMethod(this.transform);
        }

        if (GUI.Button(new Rect(100, 200, 120, 50), "按钮B")) {
            Template b = new ConcreteTemplateB();
            b.TemplateMethod(this.transform);
        }
    }
}
