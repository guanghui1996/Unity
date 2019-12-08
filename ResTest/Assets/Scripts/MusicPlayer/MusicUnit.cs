/// ========================================================
/// 描述：
/// 问题小记： 
/// 作者：HUI 
/// 创建时间：2019-11-27 00:20:50
/// 版 本：1.0
/// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicUnit : MonoBehaviour{
    private string musicName;
    private string singerName;
    private int number;
    [SerializeField]
    private Text _music;
    [SerializeField]
    private Text _singer;
    [SerializeField]
    private Text _index;

    public void InitCellInfo(string musicname,string singername,int index) {
        musicName = musicname;
        singerName = singername;
        number = index;

        _music.text = musicname;
        _singer.text = singername;
        _index.text = index.ToString();
    }

    public void OnBtnClick() {
        Debug.Log("切换歌曲");
        string totalName = singerName + "-" + musicName;
        GameObject.Find("AudioManager").GetComponent<MusicManager>().ChangeMusic(totalName);
    }

    public string MusicName
    {
        get
        {
            return musicName;
        }

        set
        {
            musicName = value;
        }
    }
    public string SingerName
    {
        get
        {
            return singerName;
        }

        set
        {
            singerName = value;
        }
    }
    public int Number
    {
        get
        {
            return number;
        }

        set
        {
            number = value;
        }
    }
}
