using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour {

	public MyButton background;
	public MyButton replayButton;
	public MyButton menuButton;
	public UILabel score;

	// Use this for initialization
	void Start () {
		background.signalOnClick.AddListener (menu);
		replayButton.signalOnClick.AddListener (replay);
		menuButton.signalOnClick.AddListener (menu);
	}


	void replay(){
		SceneManager.LoadScene ("GameField");

	}

	void menu(){
		SceneManager.LoadScene ("Menu");

	}

	public void setScore(string scoreText){
		score.text = scoreText;
	}


}
