using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextData : MonoBehaviour {

    private Text MyText = null;

    private TextAsset TextData = null;

    private void Awake()
    {
        MyText = GetComponent<Text>();

        TextData = Resources.Load("AnimText") as TextAsset;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MyText.text = TextData.text;
	}
}
