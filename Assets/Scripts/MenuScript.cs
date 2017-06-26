using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour {
	public MyButton musicButton;
	public MyButton trainingButton;
	public MyButton twoPlayersByGoolsButton;
	public MyButton twoPlayersByTimeButton;
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
		if(SoundManager.Instance.isSoundOn())
			musicSource.Play ();
		music = SoundManager.Instance.isSoundOn ();
		changeMusic ();
		changeMusic ();
		trainingButton.signalOnClick.AddListener (training);
		twoPlayersByGoolsButton.signalOnClick.AddListener (twoPlayersByGools);
		twoPlayersByTimeButton.signalOnClick.AddListener (twoPlayersByTime);
		musicButton.signalOnClick.AddListener (changeMusic);
	}

	void training(){
		SceneManager.LoadScene ("Select two players");
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
