using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToBase : MonoBehaviour
{

    private bool canReturn;
    public bool isReturning;
    public Vector2 playerPos;
    public VectorValue playerStorage;
    public PlayerMovement player;
    private int sceneIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    //Pick Up Item (place item over head)
    void Update()
    {

        if (sceneIndex == 2)
        {
            if (canReturn && Input.GetKey("e"))
            {
                playerStorage.initialValue = playerPos;
                isReturning = true;
                SceneManager.LoadScene(sceneIndex--);
            }
        }

        if (sceneIndex == 1)
        {
            if (canReturn && Input.GetKey("e"))
            {
                playerStorage.initialValue = playerPos;
                isReturning = true;
                SceneManager.LoadScene(sceneIndex++);
            }
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
