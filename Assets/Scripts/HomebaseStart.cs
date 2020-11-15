using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomebaseStart : MonoBehaviour
{
    public static bool adventuring = false;
    
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
            SceneManager.LoadScene(Constants.adventureSceneIndex);
            Debug.Log(SceneManager.GetActiveScene());
            Homebase.adventuresRemaining--;
            adventuring = true;
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
