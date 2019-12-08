/// ========================================================
/// 描述：
/// 问题小记： 
/// 作者：HUI 
/// 创建时间：2019-11-27 01:08:33
/// 版 本：1.0
/// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTest : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;

    private Transform content;

	// Use this for initialization
	void Start () {
        content = GameObject.Find("Content").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.transform.parent = content;
            }
        }
	}
}
