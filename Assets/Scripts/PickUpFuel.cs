using UnityEngine;

public class PickUpFuel : MonoBehaviour
{

    public bool canPickUp;
    private HeldFuel heldFuel;
    public bool isMaxFuel = false;
    public bool didGetFuel = false;

    public GameObject FuelEmpty;
    public GameObject FuelOne;
    public GameObject FuelTwo;
    public GameObject FuelThree;
    public GameObject FuelFour;
    public GameObject FuelFive;

    // Get the code from HeldFuel
    void Start()
    {
        heldFuel = GameObject.FindGameObjectWithTag("Player").GetComponent<HeldFuel>();
    }

    // Get the Fuel
    void Update()
    {
        if (canPickUp && Input.GetKey("e") && !isMaxFuel)
        {
            didGetFuel = true;
            addFuel();
            updateFuelTank();
            Destroy(gameObject);
            didGetFuel = false;
        }

        if (heldFuel.numFuel >= heldFuel.maxFuel)
        {
            isMaxFuel = true;
        }

        else
        {
            isMaxFuel = false;
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

    // Counts how much fuel you got
    private void addFuel()
    {
        heldFuel.numFuel++;
    }

    //changes the fuel tank depending on the number of fuel
    private void updateFuelTank()
    {
        switch (heldFuel.numFuel)
        {
            case 1:
                Instantiate(FuelOne, heldFuel.FuelTankLocation.transform);
                break;

            case 2:
                Instantiate(FuelTwo, heldFuel.FuelTankLocation.transform);
                break;

            case 3:
                Instantiate(FuelThree, heldFuel.FuelTankLocation.transform);
                break;

            case 4:
                Instantiate(FuelFour, heldFuel.FuelTankLocation.transform);
                break;

            case 5:
                Instantiate(FuelFive, heldFuel.FuelTankLocation.transform);
                break;

            default:
                Instantiate(FuelEmpty, heldFuel.FuelTankLocation.transform);
                break;
        }
    }
}
