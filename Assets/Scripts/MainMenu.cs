using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void playGame()
    {
        SceneManager.LoadScene(Constants.tradingSceneIndex);
    }

    public void quitGame()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
