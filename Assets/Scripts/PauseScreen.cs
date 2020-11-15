using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{

    public void onClickHeader()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }

 public void quitApplication()
    {
        Application.Quit();
        Debug.Log("Quit!");
        
    }
}
