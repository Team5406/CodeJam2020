using UnityEngine;

public class DepositFuel : MonoBehaviour
{

    private HeldFuel heldFuel;
    public int maxFuel = 25;
    public bool canDeposit;
    public GameObject fuelLoaderLocation;
    public bool isDepositing;
    private InventoryManagment inventory;

    public GameObject fuelLoaderEmpty;
    public GameObject fuelLoaderOne;
    public GameObject fuelLoaderTwo;
    public GameObject fuelLoaderThree;
    public GameObject fuelLoaderFour;
    public GameObject fuelLoaderFive;
    public GameObject fuelLoaderSix;
    public GameObject fuelLoaderSeven;
    public GameObject fuelLoaderEight;
    public GameObject fuelLoaderNine;
    public GameObject fuelLoaderTen;
    public GameObject fuelLoaderEleven;
    public GameObject fuelLoaderTwelve;
    public GameObject fuelLoaderThirteen;
    public GameObject fuelLoaderFourteen;
    public GameObject fuelLoaderFifteen;
    public GameObject fuelLoaderSixteen;
    public GameObject fuelLoaderSeventeen;
    public GameObject fuelLoaderEighteen;
    public GameObject fuelLoaderNineteen;
    public GameObject fuelLoaderTwenty;
    public GameObject fuelLoaderTwentyOne;
    public GameObject fuelLoaderTwentyTwo;
    public GameObject fuelLoaderTwentyThree;
    public GameObject fuelLoaderTwentyFour;
    public GameObject fuelLoaderFull;


    // Start is called before the first frame update
    void Start()
    {
        heldFuel = GameObject.FindGameObjectWithTag("Player").GetComponent<HeldFuel>();
        updateFuelLoader();

    }

    // Update is called once per frame
    void Update()
    {
        if(canDeposit && Input.GetKey("e"))
        {
            isDepositing = true;
            heldFuel.currentFuel += heldFuel.numFuel;
            canDeposit = false;
            Debug.Log("Deposit Has " + heldFuel.currentFuel + " Fuel");
            InventoryManagment.updatePlayerFuelInventory(heldFuel.currentFuel);

            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            updateFuelLoader();
            isDepositing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canDeposit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canDeposit = false;
        }
    }

    void updateFuelLoader()
    {
        if(heldFuel.currentFuel >= 24)
        {
            heldFuel.currentFuel = 25;
        }

        switch (heldFuel.currentFuel)
        {
            case 1:
                Instantiate(fuelLoaderOne, fuelLoaderLocation.transform);
                break;

            case 2:
                Instantiate(fuelLoaderTwo, fuelLoaderLocation.transform);
                break;

            case 3:
                Instantiate(fuelLoaderThree, fuelLoaderLocation.transform);
                break;

            case 4:
                Instantiate(fuelLoaderFour, fuelLoaderLocation.transform);
                break;

            case 5:
                Instantiate(fuelLoaderFive, fuelLoaderLocation.transform);
                break;

            case 6:
                Instantiate(fuelLoaderSix, fuelLoaderLocation.transform);
                break;

            case 7:
                Instantiate(fuelLoaderSeven, fuelLoaderLocation.transform);
                break;

            case 8:
                Instantiate(fuelLoaderEight, fuelLoaderLocation.transform);
                break;

            case 9:
                Instantiate(fuelLoaderNine, fuelLoaderLocation.transform);
                break;

            case 10:
                Instantiate(fuelLoaderTen, fuelLoaderLocation.transform);
                break;

            case 11:
                Instantiate(fuelLoaderEleven, fuelLoaderLocation.transform);
                break;

            case 12:
                Instantiate(fuelLoaderTwelve, fuelLoaderLocation.transform);
                break;

            case 13:
                Instantiate(fuelLoaderThirteen, fuelLoaderLocation.transform);
                break;

            case 14:
                Instantiate(fuelLoaderFourteen, fuelLoaderLocation.transform);
                break;

            case 15:
                Instantiate(fuelLoaderFifteen, fuelLoaderLocation.transform);
                break;

            case 16:
                Instantiate(fuelLoaderSixteen, fuelLoaderLocation.transform);
                break;

            case 17:
                Instantiate(fuelLoaderSeventeen, fuelLoaderLocation.transform);
                break;

            case 18:
                Instantiate(fuelLoaderEighteen, fuelLoaderLocation.transform);
                break;

            case 19:
                Instantiate(fuelLoaderNineteen, fuelLoaderLocation.transform);
                break;

            case 20:
                Instantiate(fuelLoaderTwenty, fuelLoaderLocation.transform);
                break;

            case 21:
                Instantiate(fuelLoaderTwentyOne, fuelLoaderLocation.transform);
                break;

            case 22:
                Instantiate(fuelLoaderTwentyTwo, fuelLoaderLocation.transform);
                break;

            case 23:
                Instantiate(fuelLoaderTwentyThree, fuelLoaderLocation.transform);
                break;

            case 24:
                Instantiate(fuelLoaderTwentyFour, fuelLoaderLocation.transform);
                break;

            case 25:
                Instantiate(fuelLoaderFull, fuelLoaderLocation.transform);
                break;

            default:
                Instantiate(fuelLoaderEmpty, fuelLoaderLocation.transform);
                break;
        }
    }
}
