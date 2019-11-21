// ========================================================
// 描述：OnTriggerEnter OnTriggerStay测试代码
// 作者：HUI 
// 创建时间：2019-11-20 22:06:25
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCtrl : MonoBehaviour {

    [SerializeField]
    private int _speed;

    [SerializeField]
    private GameObject cube2;

    private int count = 0;
    private int stay_count = 0;

    private bool _flag = false;

    private bool m_flag = false;

    private bool color_flag = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * _speed);
        }
        else if (Input.GetKeyUp(KeyCode.C)) {
            if (_flag)
            {
                cube2.transform.localScale *= 2;
                _flag = false;
            }
            else
            {
                cube2.transform.localScale /= 2;
                _flag = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (m_flag)
            {
                this.gameObject.transform.localScale *= 2;
                m_flag = false;
            }
            else
            {
                this.gameObject.transform.localScale /= 2;
                m_flag = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter this name is" + this.gameObject.name + "And other name is" + other.gameObject.name + "count is " + count);
        count++;



        Material material = other.gameObject.GetComponent<MeshRenderer>().material;

        if (color_flag)
        {
            material.color = Color.white;
            color_flag = false;
        }
        else
        {
            material.color = Color.red;
            color_flag = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay this name is" + this.gameObject.name + "And other name is" + other.gameObject.name + "count is " + stay_count);
        stay_count++;
    }
}
