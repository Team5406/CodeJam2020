using UnityEngine;

public class UpdateFuel : MonoBehaviour
{

    private HeldFuel heldFuel;
    private PickUpFuel pickUpFuel;

    // Start is called before the first frame update
    void Start()
    {
        heldFuel = GameObject.FindGameObjectWithTag("Player").GetComponent<HeldFuel>();
        pickUpFuel = GameObject.FindGameObjectWithTag("fuel").GetComponent<PickUpFuel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpFuel.didGetFuel && Input.GetKey("e"))
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
