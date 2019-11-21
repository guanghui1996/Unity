using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectCtrl : MonoBehaviour {

    private Subject subject;

	// Use this for initialization
	void Start () {
        init();
    }

    void init() {
        subject = new Subject();

        Observer achieve = new Achievement("achieve");
        Observer achieve2 = new Achievement("achieve2");
        Observer backpage1 = new Backpack("backpage1");
        Observer backpage2 = new Backpack("backpage2");
        Observer phy = new Physics("phy");
        Observer phy2 = new Physics("phy2");

        achieve.Register(subject);
        achieve2.Register(subject);
        backpage1.Register(subject);
        backpage2.Register(subject);
        phy.Register(subject);
        phy2.Register(subject);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyUp(KeyCode.I)) {
        //    init();
        //}

        if (Input.GetMouseButtonUp(0)) {
            subject.Notify();
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            Observer backpage1 = new Backpack("backpage1");
            backpage1.Register(subject);
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            Observer phy = new Physics("phy");
            phy.Register(subject);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Observer achieve = new Achievement("achieve");
            achieve.Register(subject);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            ArrayList list = subject.ArrayList;
            int num = list.Count;
            Debug.Log("被观察者队列总数为：" + num);

            if (num >= 1) {

                Observer observer = list[num - 1] as Observer;

                Debug.Log("要删除的观察者是 " + observer.GetName());
                observer.UnRegister(subject);
            }
        }

	}
}
