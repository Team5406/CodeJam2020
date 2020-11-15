using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomebaseStart : MonoBehaviour
{

    private bool canStart;
    public bool isLeaving;
    public Vector2 playerPos;
    public VectorValue playerStorage;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    //Pick Up Item (place item over head)
    void Update()
    {

        if (canStart && Input.GetKey("e"))
        {
            playerStorage.initialValue = playerPos;
            isLeaving = true;
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
