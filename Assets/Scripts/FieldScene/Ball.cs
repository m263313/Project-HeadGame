using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public static Ball current;
    public Vector3 startPosition;
    // Use this for initialization
    void Start () {
        current = this;
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Намагаємося отримати компонент 
        // SelfControl rabit = collider.GetComponent<SelfControl>();
       RightGates right = collider.GetComponent<RightGates>();

        if (right != null)
        {
            ScoreController.current.RightMissedGoal();
        }

        LeftGates left = collider.GetComponent<LeftGates>();

        if (left != null)
        {
            ScoreController.current.LeftMissedGoal();
        }

    }
}
