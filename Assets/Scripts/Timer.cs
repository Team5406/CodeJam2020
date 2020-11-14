using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{


    public float timeRemaining = 150;
    public float minute;
    public float second;
    public bool timerIsRunning = false;
    bool timerCanRun;
    // public HomebaseStart adventure;

    public void timer()
    {

        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log(timeRemaining);
            minute = Mathf.FloorToInt(timeRemaining / 60);
            second = Mathf.FloorToInt(timeRemaining % 60);
        }
        else
        {
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            timerIsRunning = false;

            /* if (adventure.adventuring)
             {
                 SceneManager.LoadScene(Constants.homebaseSceneIndex);
                 Debug.Log("You Blacked Out!");
             }*/
        }
    }
}
        


