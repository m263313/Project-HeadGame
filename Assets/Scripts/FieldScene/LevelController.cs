using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    string mode;
    bool isByGoals=false;
    bool isByTime = false;
    bool isFinished = false;
    public float matchTime = 60f;
    public UILabel timePanel;
	public GameObject winPanelPrefab;
	bool isPanelCreated=false;

    public GameObject leftPlayer;
    public GameObject rightPlayer;
    public List<GameObject> leftPlayerList;
    public List<GameObject> rightPlayerList;

	public MyButton musicButton;
	public Sprite soundOn;
	public Sprite soundOff;
	public AudioClip musicClip = null;
	AudioSource musicSource = null;
	bool music;





    // Use this for initialization
    void Start () {
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.clip = musicClip;
		musicSource.loop = true;
		musicSource.volume = 0.5f;
		if(SoundManager.Instance.isSoundOn())
			musicSource.Play ();
		music = SoundManager.Instance.isSoundOn ();
		changeMusic ();
		changeMusic ();
		musicButton.signalOnClick.AddListener (changeMusic);

		Time.timeScale = 1f;
        mode = PlayerPrefs.GetString("mode", Mode.training);
        if (mode.Equals(Mode.training))
        {
            StartTraining();
        }
        if (mode.Equals(Mode.twoPlayersByGools))
        {
            StartByGoals();
        }
        if (mode.Equals(Mode.twoPlayersByTime))
        {
            StartByTime();
        }

        SetPlayers();
    }
	
	// Update is called once per frame
	void Update () {

		if (isFinished&&(!isPanelCreated)) {
			createWinPanel ();
			isPanelCreated = true;
		}

        if (isByGoals)
        {
            if (ScoreController.current.RightMissed > 4 || ScoreController.current.LeftMissed > 4)
            {
                isFinished = true;
                Time.timeScale = 0f;

            }
        }
        if (isByTime)
        {
            if (matchTime <= 0)
            {
                isFinished = true;
                Time.timeScale = 0f;

            }
            matchTime -= Time.deltaTime;
            timePanel.text = ("" +Math.Truncate(matchTime));
        }


	}
    void StartTraining()
    {
        Destroy(GameObject.Find("timeLabel"));
    }
    void StartByGoals()
    {
        Destroy(GameObject.Find("timeLabel"));
        isByGoals = true;
    }
    void StartByTime()
    {
        isByTime = true;
    }

	public void createWinPanel(){
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild (parent, winPanelPrefab);
		WinPanel win = obj.GetComponent<WinPanel>();
		win.setScore (ScoreController.current.RightMissed+":"+ScoreController.current.LeftMissed);
	}
    void SetPlayers()
    {
        int right = PlayerPrefs.GetInt("rightPlayer", 1);
        int left = PlayerPrefs.GetInt("leftPlayer", 1) ;
        leftPlayer.AddChild(leftPlayerList[left]);
        rightPlayer.AddChild(rightPlayerList[right]);

        // leftPlayer.SetActive(false);

        //explosion.transform.position = charExplode.transform.position;
        // explosion.transform.rotation = charExplode.transform.rotation;
        //  explosion.SetActive(true);
        // rightPlayer = rightPlayerList[right];
        //     leftPlayer = leftPlayerList[left];
    }

	void changeMusic(){
		if (music) {
			musicSource.Pause ();
			musicButton.GetComponent<UIButton> ().normalSprite2D = soundOff;
			SoundManager.Instance.setSoundOn (false);
			music = false;
		} else {
			musicSource.Play ();
			musicButton.GetComponent<UIButton> ().normalSprite2D = soundOn;
			SoundManager.Instance.setSoundOn (true);
			music = true;
		}
	}
}
