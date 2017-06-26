using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    public static ScoreController current ;
    int leftMissed = 0;
    int rightMissed = 0;
  public  UILabel score;

	public AudioClip goolClip = null;
	AudioSource goolSource = null;

    public int RightMissed
    {
        get
        {
            return rightMissed;
        }

        set
        {
            rightMissed = value;
        }
    }

    public int LeftMissed
    {
        get
        {
            return leftMissed;
        }

        set
        {
            leftMissed = value;
        }
    }

    // Use this for initialization
    void Start () {
        current = this;
		goolSource = gameObject.AddComponent<AudioSource>();
		goolSource.clip = goolClip;
		goolSource.loop = false;
	}
	
	// Update is called once per frame
	void Update () {
        score.text = rightMissed + ":"+leftMissed;
	}
    public void LeftMissedGoal()
    {
		if(SoundManager.Instance.isSoundOn())
		goolSource.Play ();
        leftMissed++;
        ReturnForPositions();
    }
    public void RightMissedGoal()
    {
		if(SoundManager.Instance.isSoundOn())
		goolSource.Play ();
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
