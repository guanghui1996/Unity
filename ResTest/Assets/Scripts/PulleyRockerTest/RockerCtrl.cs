// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-21 21:19:32
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockerCtrl : MonoBehaviour {
    /// <summary>
    /// 底座圆盘
    /// </summary>
    private RectTransform rocker;
    /// <summary>
    /// 移动小球
    /// </summary>
    private RectTransform ball;
    /// <summary>
    /// 圆盘底座默认位置
    /// </summary>
    private Vector2 m_zeroPos;
    /// <summary>
    /// 小球的坐标向量
    /// </summary>
    private Vector2 dis;
    private Transform player;
    /// <summary>
    /// 圆盘底座半径
    /// </summary>
    [SerializeField]
    private float m_r;
    /// <summary>
    /// 玩家移动速度
    /// </summary>
    [SerializeField]
    private float m_speed;
    /// <summary>
    /// 圆盘底座跟随速度
    /// </summary>
    [SerializeField]
    private float follow_speed;

	// Use this for initialization
	void Start () {
        rocker = gameObject.GetComponent<RectTransform>();
        ball = transform.Find("ball").GetComponent<RectTransform>();
        player = GameObject.Find("player").transform;
        m_zeroPos = GetComponent<RectTransform>().anchoredPosition;
	}
	
	/// <summary>
    /// 这里想让圆盘跟随的时候动作更加圆滑  所以使圆盘的跟随速度随着与小球的距离进行变化（但是还是有点卡顿
    /// </summary>
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(Input.mousePosition);
            ball.anchoredPosition = Input.mousePosition - rocker.anchoredPosition3D;
            
            dis = ball.anchoredPosition;
            follow_speed = dis.magnitude;
            
            Debug.Log(dis.magnitude);
            if (dis.magnitude >= m_r) {
                rocker.anchoredPosition += dis.normalized * follow_speed * 5 * Time.deltaTime;
            }
            player.transform.Translate(dis.normalized * Time.deltaTime * m_speed);
        }
        if (Input.GetMouseButtonUp(0)) {
            rocker.anchoredPosition = m_zeroPos;
            ball.anchoredPosition = Vector2.zero;
        }
	}
}
