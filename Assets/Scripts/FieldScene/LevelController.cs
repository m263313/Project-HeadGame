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
	// Use this for initialization
	void Start () {
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
		win.setScore (ScoreController.current.LeftMissed+":"+ScoreController.current.RightMissed);
	}
}
