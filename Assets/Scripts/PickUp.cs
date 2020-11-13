using UnityEngine;

public class PickUp : MonoBehaviour
{

    private HeldItem heldItem;
    public GameObject item;
    private bool canPickUp;

    //get code from HeldItem.cs
    private void Start()
    {
        heldItem = GameObject.FindGameObjectWithTag("Player").GetComponent<HeldItem>();
    }

    //Pick Up Item (place item over head)
    void Update()
    {

        if(canPickUp && Input.GetKey("e"))
        {
            if (heldItem.isHolding == false)
            {
                heldItem.isHolding = true;
                Instantiate(item, heldItem.heldItemLocation.transform);
                Destroy(gameObject);
            }
        }
    }

    //Checks if player is close to pick up object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }

    //Checks if player is far to pick up object
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }

}
