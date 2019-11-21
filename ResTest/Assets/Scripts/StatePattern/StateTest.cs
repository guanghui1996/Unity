// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-20 23:04:15
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateTest : MonoBehaviour {

    private GameObject obj;
    private Controller ctrl;
    private GameObject text;

    void Awake()
    {
        text = GameObject.Find("Text");
        text.GetComponent<Text>().color = Color.blue;
        text.GetComponent<Text>().horizontalOverflow = HorizontalWrapMode.Overflow;
    }

    // Use this for initialization
    void Start () {
        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.GetComponent<MeshRenderer>().material.color = Color.red;
        //obj.name = "Cube";
        obj.transform.position = Vector3.zero;
        ctrl = new Controller(obj, new MoveToUp());
    }
	
	// Update is called once per frame
	void Update () {
        ctrl.Handle();
        // Debug.Log(obj.transform.position);
        text.GetComponent<Text>().text = ctrl.MoveState.ToString() + " " + obj.transform.position.ToString();
    }
}
