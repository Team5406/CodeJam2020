using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homebase : MonoBehaviour
{
    public static int playerScore = 0;
    public static int adventuresRemaining;
    public static int fuel = 5;
    public void Start()
    {
        adventuresRemaining = Constants.maxAdventures;
     
    }

}


