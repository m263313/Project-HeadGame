using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    public static ScoreController current ;
    int leftMissed = 0;
    int rightMissed = 0;
  public  UILabel score;
	// Use this for initialization
	void Start () {
        current = this;
	}
	
	// Update is called once per frame
	void Update () {
        score.text = rightMissed + ":"+leftMissed;
	}
    public void LeftMissedGoal()
    {
        leftMissed++;
        ReturnForPositions();
    }
    public void RightMissedGoal()
    {
        rightMissed++;
        ReturnForPositions();
    }

    void ReturnForPositions()
    {
        Ball.current.transform.position = Ball.current.startPosition;
        RightPlayer.current.transform.position = RightPlayer.current.startPosition;
        LeftPlayer.current.transform.position = LeftPlayer.current.startPosition;
    }
}
