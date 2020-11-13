using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomItem : MonoBehaviour
{
    //make into an array later
    //public GameObject[] items;
    public GameObject item;

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
        SpawnItem();
    }

    public void Update()
    {
   
    }


    void SpawnItem()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        //GameObject item = items[Random.Range(0, items.Length)];
        Instantiate(item, pos, transform.rotation);
    }
}
