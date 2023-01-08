using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UI;
    public GameObject startMenu, winMenu, heart, loseMenu, time;
    public GameObject[] hearts;

    public Text TimerText;
    public float startTimer;
    private float timer;

    public int can;
    public int maxCan;

    public bool timerStarted=false;
    private bool win=false;

    // Start is called before the first frame update
    void Start()
    {
        UI = this;
        startMenu.SetActive(true);
        timer = startTimer;
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            timer = timer - Time.deltaTime;
        }
        if(timer<=0)
        {
            timerStarted = false;
            win = true;
            timer= 0;   
        }
        TimerText.text = timer.ToString("f0");
        timer-=Time.deltaTime;

        if (win)
        {
            winMenu.SetActive(true);
            time.SetActive(false);
            heart.SetActive(false);
            Time.timeScale= 0f;
        }
        if (can <= 0)
        {
            LoseMenu();
        }
        
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        time.SetActive(true);
        heart.SetActive(true);
        timerStarted = true;
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoseMenu()
    {
        loseMenu.SetActive(true);
        time.SetActive(false);
        Time.timeScale = 0f;
        Debug.Log("Kaybettin");
    }

    public void canazalt()
    {
        can--;
        Health();

    }
    public void Health()
    {
        for(int i =0; i<maxCan; i++)
        {
            hearts[i].SetActive(false);
        }
        for(int i =0; i<can;i++)
        {
            hearts[i].SetActive(true);
        }
    }
}
