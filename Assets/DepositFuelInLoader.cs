using UnityEngine;

public class DepositFuelInLoader : MonoBehaviour
{

    private DepositFuel fuelLoader;
    private HeldFuel heldFuel;

    // Start is called before the first frame update
    void Start()
    {
        heldFuel = GameObject.FindGameObjectWithTag("Player").GetComponent<HeldFuel>();
        fuelLoader = GameObject.FindGameObjectWithTag("loader").GetComponent<DepositFuel>();
    }

    // Update is called once per frame
    void Update()
    {

        fuelLoader = GameObject.FindGameObjectWithTag("loader").GetComponent<DepositFuel>();

        if (fuelLoader.canDeposit && Input.GetKey("e"))
        {
            Debug.Log("Depot");
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        if(transform.childCount <= 0)
        {
            heldFuel.numFuel = 0;
        }
    }
}
