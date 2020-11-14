using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homebase : MonoBehaviour
{
    public int playerScore = 10;
    public int adventuresRemaining = Constants.numberOfAdventures;
    public int fuel = 5;
    void Start()
    {
        PlayerPrefs.SetInt("playerScore", playerScore);

    }
    void Update()
    {
    }
}

