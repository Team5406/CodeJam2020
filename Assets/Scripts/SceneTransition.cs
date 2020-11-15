using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPos;
    public VectorValue playerStorage;
    public bool isTransporting;
    private bool canTransport;
    public GameObject player;

    private void Update()
    {
        if (canTransport && Input.GetKey("e"))
        {
            isTransporting = true;
            SceneManager.LoadScene(sceneToLoad);
            playerStorage.initialValue = playerPos;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canTransport = true;


        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            canTransport = false;
        }
    }
}
