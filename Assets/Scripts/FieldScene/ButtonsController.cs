using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour {
    public MyButton pauseButton;
    public MyButton menuButton;
    bool isPaused=false;
    public GameObject pausePanel;
    // Use this for initialization
    void Start () {
        this.menuButton.signalOnClick.AddListener(this.onMenu);
        this.pauseButton.signalOnClick.AddListener(this.onPause);
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            onPause();
        }
    }
    void onPause()
    {
        if (isPaused)
        {
            Destroy(GameObject.Find("PausePanel"));
            Time.timeScale = 1f;
        }
        else
        {
 
                  //Знайти батьківський елемент
            GameObject parent = UICamera.first.transform.parent.gameObject;
            //Створити 
            GameObject obj = NGUITools.AddChild(parent, pausePanel);
            Time.timeScale = 0f;
        }

        isPaused =!isPaused;
    } 
    void onMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
