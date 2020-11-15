using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomItem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    System.Random randomItem = new System.Random();
    public GameObject rock;


    // the range of X
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    // the range of y
    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;


    void Start()
    {
        for (int i = 0; i < 60; i++)
        {
            SpawnItem();
        }

        for(int i = 0; i< 50; i++)
        {
            SpawnFuel();
            SpawnRock();
        }
    }

    public void Update()
    { 
        
    }


    void SpawnItem()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        GameObject item = Probability();
        Instantiate(item, pos, transform.rotation);
    }

    void SpawnFuel()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        Instantiate(items[10], pos, transform.rotation);
    }

    void SpawnRock()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        Instantiate(rock, pos, transform.rotation);
    }

    GameObject Probability()
    {

        int prob = randomItem.Next(1, 20);

        if (prob < 2)
        {
            //5% probabilty of coming to this block
            GameObject item = items[Random.Range(0, 2)];
            return item;
        }
        else if (prob < 4)
        {
            //20% probabilty
            GameObject item = items[Random.Range(2, 3)];
            return item;
        }
        else if (prob < 10)
        {
            //50% probabilty
            GameObject item = items[Random.Range(3, 6)];
            return item;
        }
        else if (prob < 15)
        {
            //75% probabilty
            GameObject item = items[Random.Range(6, 8)];
            return item;
        }
        else
        {
            GameObject item = items[Random.Range(8, 10)];
            return item;
        }
    }
}
