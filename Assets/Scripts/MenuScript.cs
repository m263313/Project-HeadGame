using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour {
	public MyButton trainingButton;
	public MyButton twoPlayersByGoolsButton;
	public MyButton twoPlayersByTimeButton;
	// Use this for initialization
	void Start () {
		trainingButton.signalOnClick.AddListener (training);
		twoPlayersByGoolsButton.signalOnClick.AddListener (twoPlayersByGools);
		twoPlayersByTimeButton.signalOnClick.AddListener (twoPlayersByTime);
	}

	void training(){
		SceneManager.LoadScene ("Select player");
		PlayerPrefs.SetString ("mode", Mode.training);
	}

	void twoPlayersByGools(){
		SceneManager.LoadScene ("Select two players");
		PlayerPrefs.SetString ("mode", Mode.twoPlayersByGools);
	}
	
	void twoPlayersByTime(){
		SceneManager.LoadScene ("Select two players");
		PlayerPrefs.SetString ("mode", Mode.twoPlayersByTime);
	}
}
