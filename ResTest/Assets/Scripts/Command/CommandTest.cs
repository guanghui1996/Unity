// ========================================================
// 描述：
// 作者：HUI 
// 创建时间：2019-11-22 22:36:42
// 版 本：1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTest : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    private InputHandler input;

    //private Command right;
    //private Command left;
	// Use this for initialization
	void Start () {
        //right = new RightCommand();
        //left = new LeftCommand();
        input = new InputHandler();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(KeyCode.A))
        //{
        //    left.execute(player);
        //}
        //else if (Input.GetKey(KeyCode.D)) {
        //    right.execute(player);
        //}
        Command command = input.handleInput();
        command.execute(player);
	}
}
