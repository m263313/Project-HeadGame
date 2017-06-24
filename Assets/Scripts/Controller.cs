using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	public MyButton nextButton1;
	public MyButton nextButton2;
	public MyButton prevButton1;
	public MyButton prevButton2;
	public MyButton playButton;
	public UILabel firstPlayerLabel;
	public UILabel secondPlayerLabel;
	public UI2DSprite firstPlayerSprite;
	public UI2DSprite secondPlayerSprite;
	public List<Sprite> sprites;
	public List<string> names;
	int countFirst;
	int countSecond;
	public int numberOfPlayers;
	// Use this for initialization
	void Start () {
		numberOfPlayers--;
		countFirst = 0;
		countSecond = 1;
		refresh1 ();
		if(secondPlayerSprite!=null)
		refresh2 ();
		this.nextButton1.signalOnClick.AddListener (this.next1);
		if(secondPlayerSprite!=null)
		this.nextButton2.signalOnClick.AddListener (this.next2);
		this.prevButton1.signalOnClick.AddListener (this.prev1);
		if(secondPlayerSprite!=null)
		this.prevButton2.signalOnClick.AddListener (this.prev2);
		this.playButton.signalOnClick.AddListener (this.play);
	}
	
	void next1(){
		if(countFirst>=numberOfPlayers){
			countFirst = 0;
		}else{
			countFirst++;
		}
		refresh1 ();
	}

	void next2(){
		if(countSecond>=numberOfPlayers){
			countSecond = 0;
		}else{
			countSecond++;
		}
		refresh2 ();
	}

	void prev1(){
		if(countFirst<=0){
			countFirst = numberOfPlayers;
		}else{
			countFirst--;
		}

		refresh1 ();
	}

	void prev2(){
		if(countSecond<=0){
			countSecond = numberOfPlayers;
		}else{
			countSecond--;
		}
		refresh2 ();
	}

	void refresh1(){
		this.firstPlayerSprite.sprite2D = sprites [countFirst];
		this.firstPlayerLabel.text = names [countFirst];
		firstPlayerSprite.flip = UIBasicSprite.Flip.Horizontally;
	}

	void refresh2(){
		this.secondPlayerSprite.sprite2D = sprites [countSecond];
		this.secondPlayerLabel.text = names [countSecond];
	}

	void play(){
		PlayerPrefs.SetInt ("leftPlayer",countFirst);
		PlayerPrefs.SetInt ("rightPlayer",countSecond);
		SceneManager.LoadScene ("GameField");
	}

}
