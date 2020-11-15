using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManagment : MonoBehaviour
{
    //global variable for storing the items in the player's possession  
    public static Dictionary<string, int> playerInventory = new Dictionary<string, int>();
    public static Dictionary<string, int> opponentInventory = new Dictionary<string, int>();

    public static float lastGameTime = 0;
    public static System.Random rnd = new System.Random();
    public static int tradeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        initInventory();
        updatePlayerInventory("fuelTankLg", 1);
        updatePlayerInventory("fuelTankMd", 1);
        updatePlayerInventory("fuelTankLg", 1);
        updatePlayerInventory("fuelTankSm", 2);
        updatePlayerInventory("fuelTankSm", -1);
        updatePlayerInventory("solarPanel", 2);
        updatePlayerInventory("batteryLg", 2);
        updatePlayerInventory("engineMd", 3);
        updatePlayerFuelInventory(4);
        updatePlayerFuelInventory(2);
        updatePlayerFuelInventory(4);
        updatePlayerFuelInventory(5);
        updatePlayerFuelInventory(5);

    }

    // Update is called once per frame
    void Update()
    {
        logPlayerInventory();
        Debug.Log("Score: " + calculatePlayerScore());
        calculateOpponentInventory();
        logOpponentInventory();
        Debug.Log("Score: " + calculateOpponentScore());
        switchItems("fuelTankLg", "fuelTankSm");
        logPlayerInventory();
        logOpponentInventory();
        pickItemsToTrade();
        pickItemsToTrade();
        pickItemsToTrade();
        pickItemsToTrade();
        pickItemsToTrade();

        string[] items = pickItemsToTrade();
        Debug.Log(items[0]);
        Debug.Log(items[1]);
    }

    public static string[] pickItemsToTrade()
    {
        var playerItems = playerInventory
          .Where(entry => entry.Value > 0 && entry.Key != "fuel");

        double playerTotal = 0;
        foreach (KeyValuePair<string, int> entry in playerItems)
        {
            playerTotal += entry.Value * Constants.scoreableItems[entry.Key].probability;
        }

        double threshold = rnd.NextDouble();
        string playerItem = "";
        double total = 0;
        //Debug.Log("pT: " + threshold);
        foreach (KeyValuePair<string, int> entry in playerItems)
        {
            total += (entry.Value * Constants.scoreableItems[entry.Key].probability / playerTotal);
            if (threshold <= total)
            {
                playerItem = entry.Key;
                break;
            }
        }


        var opponentItems = opponentInventory
          .Where(entry => entry.Value > 0 && entry.Key != "fuel");


        double opponentTotal = 0;
        foreach (KeyValuePair<string, int> entry in opponentItems)
        {
            opponentTotal += entry.Value * Constants.scoreableItems[entry.Key].probability;
        }

        double opponentThreshold = rnd.NextDouble();
        double bias = 1 - Math.Exp(-1 * Math.Pow((tradeCount - 7), 2) / (2 * Math.Pow(4, 2)));
        threshold = opponentThreshold * bias;
        Console.WriteLine("oT: " + opponentThreshold + ", b: " + bias + ", t: " + threshold);
        string opponentItem = "";
        total = 0;
        foreach (KeyValuePair<string, int> entry in opponentItems)
        {
            total += (entry.Value * Constants.scoreableItems[entry.Key].probability / opponentTotal);
            if (threshold <= total)
            {
                opponentItem = entry.Key;
                break;
            }
        }

        tradeCount++;
        string[] items = { playerItem, opponentItem };
        return items;
    }


    public static void calculateOpponentInventory()
    {
        float currentTime = Time.time;
        float availableTime = currentTime - lastGameTime;
        int adventureTime;
        do
        {
            adventureTime = rnd.Next(15, 61);
            if (adventureTime <= availableTime)
            {
                double rndProb = rnd.Next(0, 101) / 100.0;
                var matches = Constants.scoreableItems
                  .Where(entry => entry.Key != "fuel")
                  .OrderBy(entry => entry.Value.probability);
                double advProb = (adventureTime - 15) / 45.0;
                double total = 0;
                double threshold = advProb + rndProb - Math.Floor(advProb + rndProb);
                string itemKey = "";

                foreach (KeyValuePair<string, Constants.scoreableItem> entry in matches)
                {
                    total += entry.Value.probability;
                    if (threshold <= total)
                    {
                        itemKey = entry.Key;
                        break;
                    }
                }
                updateOpponentInventory(itemKey, 1);
                updateOpponentFuelInventory((int)(advProb * 3));
                availableTime -= adventureTime;
            }
        } while (adventureTime < availableTime);
        lastGameTime = currentTime - availableTime;
    }

    public static int updatePlayerFuelInventory(int count)
    {
        return updateFuelInventory(playerInventory, count);
    }

    public static int updateOpponentFuelInventory(int count)
    {
        return updateFuelInventory(opponentInventory, count);
    }

    public static int updatePlayerInventory(string item, int count)
    {
        return updateInventory(playerInventory, item, count);
    }

    public static int updateOpponentInventory(string item, int count)
    {
        return updateInventory(opponentInventory, item, count);
    }



    public static void logPlayerInventory()
    {
        logInventory(playerInventory);
    }
    public static void logOpponentInventory()
    {
        logInventory(opponentInventory);
    }

    public static double calculatePlayerScore()
    {
        return calculateScore(playerInventory);
    }
    public static double calculateOpponentScore()
    {
        return calculateScore(opponentInventory);
    }

    public static void switchItems(string playerItem, string opponentItem)
    {
        playerInventory[playerItem]--;
        playerInventory[opponentItem]++;
        opponentInventory[playerItem]++;
        opponentInventory[opponentItem]--;
    }

    /*adds fuel to the inventory observing the limit. Returns the number of fuel added
    count: a positive or negative number representing the number of fuel available to add*/
    public static int updateFuelInventory(Dictionary<string, int> dict, int count)
    {
        int used = 0;
        if (Constants.objectLimits["fuel"] - dict["fuel"] > count)
        {
            updateInventory(dict, "fuel", count);
            used = count;
        }
        else
        {
            used = Constants.objectLimits["fuel"] - dict["fuel"];
            updateInventory(dict, "fuel", used);
        }
        return used;

    }

    /*adds or removes an item from inventory. Returns the updated count
    item: the key of the item being modified in the playerInventory
    count: a positive or negative number representing the change in items*/

    public static int updateInventory(Dictionary<string, int> dict, string item, int count)
    {
        dict[item] += count;
        if (dict[item] < 0)
        {
            dict[item] = 0;
        }
        return dict[item];
    }

    /*Initializes the playerInventory variable and sets all the counts to zero
    This method should be run when the game loads*/
    public static void initInventory()
    {
        foreach (KeyValuePair<string, Constants.scoreableItem> entry in Constants.scoreableItems)
        {
            playerInventory[entry.Key] = 0;
            opponentInventory[entry.Key] = 0;
        }
    }

    /*Convenience method: prints the current inventory list to the console. Not used by anything else.*/
    public static void logInventory(Dictionary<string, int> dict)
    {
        Debug.Log(" ------ INVENTORY START ------ ");
        foreach (KeyValuePair<string, int> entry in dict)
        {
            Debug.Log(entry.Key + ": " + entry.Value);
        }
        Debug.Log(" ------ INVENTORY END ------ ");
    }

    /*Calculates the maximum score for a particular item type (e.g. fuelTank).
    Filters the list of scoreableItems by the selected type, and then sorts by descending point order.
    Loops through the player inventory adding the score of matching items until the limit for the item category is reached.
    This ensures that items in the same category (e.g. fuelTankLg and fuelTankSm) are preferentially scored towards higher points.
    This method also imposes a limit on the number of items from a category that are included in the score*/
    public static double calculateMaxItemScore(Dictionary<string, int> dict, string item)
    {
        var matches = Constants.scoreableItems
            .Where(entry => entry.Value.objectType == item)
            .OrderByDescending(entry => entry.Value.points);

        int count = 0;
        double score = 0;

        foreach (KeyValuePair<string, Constants.scoreableItem> entry in matches)
        {
            if (dict[entry.Key] < (Constants.objectLimits[item] - count))
            {
                score += dict[entry.Key] * Constants.scoreableItems[entry.Key].points;
                count += dict[entry.Key];
            }
            else
            {
                score += (Constants.objectLimits[item] - count) * Constants.scoreableItems[entry.Key].points;
                count = Constants.objectLimits[item];
            }
        }
        return score;
    }

    /*Uses the maximum point values to implement the scoring formula and return the calculated score*/
    public static double calculateScore(Dictionary<string, int> dict)
    {

        var scoreComponents = new Dictionary<string, double>();
        foreach (KeyValuePair<string, int> entry in Constants.objectLimits)
        {
            scoreComponents[entry.Key] = calculateMaxItemScore(dict, entry.Key);
        }

        return scoreComponents["capsule"]
            + (scoreComponents["engine"] * scoreComponents["fuelTank"] * 0.1 * scoreComponents["fuel"])
            + scoreComponents["battery"] * (scoreComponents["solarPanel"] + 1);

    }

}
