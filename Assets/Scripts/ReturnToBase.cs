using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToBase : MonoBehaviour
{

    private bool canReturn;
    // Start is called before the first frame update
    void Start()
    {

    }

    //Pick Up Item (place item over head)
    void Update()
    {

        if (canReturn && Input.GetKey("e"))
        {
            SceneManager.LoadScene(Constants.homebaseSceneIndex);
        }
    }


    //Checks if player is close to pick up object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canReturn = true;
        }
    }

    //Checks if player is far to pick up object
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canReturn = false;
        }
    }
}
