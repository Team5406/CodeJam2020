using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallOpponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InventoryManagment.calculateOpponentInventory();
        string[] trades = InventoryManagment.pickItemsToTrade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
