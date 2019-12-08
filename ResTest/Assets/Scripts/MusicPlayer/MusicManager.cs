/// ========================================================
/// 描述：
/// 问题小记： 
/// 作者：HUI 
/// 创建时间：2019-12-01 15:21:11
/// 版 本：1.0
/// ========================================================
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    private AudioSource Audio;
    [SerializeField]
    private GameObject prefab;

    List<string> musics = new List<string>();

    private Text curMusicText;

    private Slider volumeCtrlSlider;

    private Transform content;

    private Button play_button;

    private Button volume_button;

    private object[] sprites;

    private int m_index;

    /// <summary>
    /// 静音前的音量大小
    /// </summary>
    private float lastVolume;

    private bool isMute;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
        content = GameObject.Find("Content").transform;
        curMusicText = GameObject.Find("curMusic").GetComponent<Text>();
        volumeCtrlSlider = GameObject.Find("volumeCtrl").GetComponent<Slider>();
        play_button = GameObject.Find("play").GetComponent<Button>();
        volume_button = GameObject.Find("volume").GetComponent<Button>();
        sprites = Resources.LoadAll("MusicPlayer/btn");
        m_index = 0;
    }

    // Use this for initialization
    void Start () {
        InitMusic();
        curMusicText.text = Audio.clip.ToString();
        volumeCtrlSlider.value = Audio.volume;
    }
	
	// Update is called once per frame
	void Update () {

	}

    void InitMusic() {
        
        musics.Add("Ava Max-Salt");
        musics.Add("DAM-Complexity");
        musics.Add("Jam-差三岁");
        musics.Add("Kayaz-Sansa Lala");
        musics.Add("Mich-Skyland");
        musics.Add("SHY Martin-Lose You Too");
        musics.Add("Simon Curtis-Beat Drop");
        musics.Add("Sophie Rose-Famous");
        musics.Add("TheFatRat-Windfall");
        musics.Add("反光镜-嘿!姑娘");
        musics.Add("杨搏-遇见");
        musics.Add("杰果-失去才懂");
        musics.Add("痛仰乐队-扎西德勒");
        musics.Add("花粥-南来北往");
        musics.Add("薛之谦-尘");
        musics.Add("许嵩-摄影艺术");
        musics.Add("许嵩-最佳歌手");
        musics.Add("郑钧-私奔");
        musics.Add("金玟岐-岁月神偷");

        for (int i = 0; i < musics.Count; i++)
        {
            GameObject obj = Instantiate(prefab);
            string[] result = musics[i].Split('-');
            obj.GetComponent<MusicUnit>().InitCellInfo(result[1], result[0], i + 1);
            obj.transform.SetParent(content);
        }
    }

    public void ChangeMusic(string name) {
        Debug.Log("manager切换音乐");
        curMusicText.text = name;
        AudioClip audioClip = Resources.Load("MusicPlayer/Audio/" + name) as AudioClip;
        m_index = musics.FindIndex(x => x == name);
        //Debug.Log(m_index);
        Audio.Stop();
        Audio.clip = audioClip;
        Audio.Play();
        Sprite tmp = sprites[53] as Sprite;
        play_button.image.sprite = tmp;
    }

    public void OnNextMusicBtnClick() {
        if (m_index == musics.Count - 1) {
            Debug.Log("没有更多歌曲了");
            return;
        }
        m_index++;
        AudioClip audioClip = Resources.Load("MusicPlayer/Audio/" + musics[m_index]) as AudioClip;
        curMusicText.text = musics[m_index];
        Audio.Stop();
        Audio.clip = audioClip;
        Audio.Play();
        Sprite tmp = sprites[53] as Sprite;
        play_button.image.sprite = tmp;
    }

    public void OnPreMusicBtnClick() {
        if (m_index == 0)
        {
            Debug.Log("没有更多歌曲了");
            return;
        }
        m_index--;
        AudioClip audioClip = Resources.Load("MusicPlayer/Audio/" + musics[m_index]) as AudioClip;
        curMusicText.text = musics[m_index];
        Audio.Stop();
        Audio.clip = audioClip;
        Audio.Play();
        Sprite tmp = sprites[53] as Sprite;
        play_button.image.sprite = tmp;
    }

    public void OnPlayOrPauseBtnClick() {
        if (Audio.isPlaying)
        {
            Audio.Pause();
            Sprite tmp = sprites[54] as Sprite;
            play_button.image.sprite = tmp;
        }
        else
        {
            Audio.Play();
            Sprite tmp = sprites[53] as Sprite;
            play_button.image.sprite = tmp;
        }
    }

    public void OnVolumeSliderChangeClick() {
        Audio.volume = volumeCtrlSlider.value;
        if (volumeCtrlSlider.value == 0)
        {
            //这里修改声音按键的图标
            Sprite tmp = sprites[58] as Sprite;
            volume_button.image.sprite = tmp;
        }
        else
        {
            Sprite tmp = sprites[34] as Sprite;
            volume_button.image.sprite = tmp;
        }
    }

    /// <summary>
    /// 这里 是声音是否开启按键的响应事件
    /// </summary>
    public void OnVolumeBtnClick() {
        if (isMute)
        {
            Sprite tmp = sprites[34] as Sprite;
            volume_button.image.sprite = tmp;

            volumeCtrlSlider.value = lastVolume;
            Audio.volume = lastVolume;
            isMute = false;

        }
        else
        {
            Sprite tmp = sprites[58] as Sprite;
            volume_button.image.sprite = tmp;

            lastVolume = Audio.volume;
            volumeCtrlSlider.value = 0;
            Audio.volume = 0;
            isMute = true;
        }
    }
}
