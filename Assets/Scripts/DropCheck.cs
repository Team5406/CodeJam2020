using UnityEngine;

public class DropCheck : MonoBehaviour
{
    public bool canDrop = true;
    public bool dropInBase = false;

    private void Update()
    {
        if (dropInBase)
        {
            dropInBase = true;
        }
    }

    //if there is a collider under the player then you can't drop
    private void OnTriggerEnter2D(Collider2D other)
    {
        canDrop = false;

        if (other.CompareTag("dropper"))
        {
            canDrop = true;
            dropInBase = true;


        }
    }

    //if there isn't a collider under the player then you can drop
    private void OnTriggerExit2D(Collider2D other)
    {
        canDrop = true;

        if (!other.CompareTag("dropper"))
        {
            dropInBase = false;
        }

    }
}
