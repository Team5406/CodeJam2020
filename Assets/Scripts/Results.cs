using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI results;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;
    int playerScore = Homebase.playerScore;
    int opponentScore = 15;

    void Start()
    {
        if(playerScore > opponentScore)
        {
            results.GetComponent<TextMeshProUGUI>().text = "WINNER!";
        }
        else if(playerScore < opponentScore)
        {
            results.GetComponent<TextMeshProUGUI>().text = "LOSE";
        }
        else if(playerScore == opponentScore)
        {
            results.GetComponent<TextMeshProUGUI>().text = "TIE";
        }

        playerScoreText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Name") + "'s Score: " + playerScore.ToString();
        opponentScoreText.GetComponent<TextMeshProUGUI>().text = "Opponent's Score: " + opponentScore.ToString();
       
    }

    public void quitApp()
    {
        Application.Quit();
    }
}
