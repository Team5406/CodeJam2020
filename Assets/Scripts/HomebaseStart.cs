using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomebaseStart : MonoBehaviour
{
    public bool adventuring = false;
    
    private bool canStart;
    public Homebase homebase;

    void Start()
    {
    }
    //Pick Up Item (place item over head)
    void Update()
    {

        if (canStart && Input.GetKey("e"))
        {
            adventuring = true;
            homebase.adventuresRemaining -= 1;
            SceneManager.LoadScene(Constants.adventureSceneIndex);
        }
    }


    //Checks if player is close to pick up object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canStart = true;
        }
    }

    //Checks if player is far to pick up object
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canStart = false;
        }
    }
}
