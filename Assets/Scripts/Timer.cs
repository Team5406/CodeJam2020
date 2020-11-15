using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Timer : MonoBehaviour
{


    public float timeRemaining = 60f;
    public float minute;
    public float second;
    public bool timerIsRunning = false;

    public TextMeshProUGUI timeLeft;

    public void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log(timeRemaining);
            minute = Mathf.FloorToInt(timeRemaining / 60);
            second = Mathf.FloorToInt(timeRemaining % 60);
            timeLeft.GetComponent<TextMeshProUGUI>().text = "Time Left " + Math.Round(timeRemaining).ToString();
        }
        if(timeRemaining<=0)
        {
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            timerIsRunning = false;

            if (HomebaseStart.adventuring)
             {
                 SceneManager.LoadScene(Constants.homebaseSceneIndex);
                 Debug.Log("You Blacked Out!");
             }
        }
    }
}
    
       
        


