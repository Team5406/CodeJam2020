using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CallOpponent : MonoBehaviour
{

    TextMeshProUGUI userItem;
    TextMeshProUGUI opponentItem;
    // Start is called before the first frame update
    void Start()
    {
        InventoryManagment.calculateOpponentInventory();
        string[] trades = InventoryManagment.pickItemsToTrade();
        userItem.GetComponent<TextMeshProUGUI>().text = "Would you like to trade " + trades[1] + " for " + trades[2] + "."
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
