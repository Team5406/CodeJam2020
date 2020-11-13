using UnityEngine;

public class DropCheck : MonoBehaviour
{
    public bool canDrop = true;

    //if there is a collider under the player then you can't drop
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canDrop = false;
    }

    //if there isn't a collider under the player then you can drop
    private void OnTriggerExit2D(Collider2D collision)
    {
        canDrop = true;
    }
}
