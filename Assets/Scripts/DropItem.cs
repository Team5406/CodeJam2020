using UnityEngine;

public class DropItem : MonoBehaviour
{

    private HeldItem heldItem;
    private DropCheck dropCheck;

    //Gets the code for HeldItem and from DropCheck
    private void Start()
    {
        heldItem = GameObject.FindGameObjectWithTag("Player").GetComponent<HeldItem>();
        dropCheck = GameObject.FindGameObjectWithTag("collider").GetComponent<DropCheck>();
    }

    /*  If the player presses "q" and if there isn't a collider under the player 
        they will spawn the object and destroy the object they are holding
        Then they update that they are not holding anything */
    public void Update()
    {
        if(Input.GetKey("q") && dropCheck.canDrop)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Spawn>().SpawnDroppedItem();
                GameObject.Destroy(child.gameObject);
            }

        }

        if (transform.childCount <= 0)
        {
            heldItem.isHolding = false;
        }
    }
}
