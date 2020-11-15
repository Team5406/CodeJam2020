using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CallOpponent : MonoBehaviour
{

    public TextMeshProUGUI tradeText;
    // Start is called before the first frame update
    void Start()
    {
        InventoryManagment.calculateOpponentInventory();
        string[] trades = InventoryManagment.pickItemsToTrade();
        tradeText.GetComponent<TextMeshProUGUI>().text = "Would you like to trade " + trades[0] + " for " + trades[1] + ".";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
