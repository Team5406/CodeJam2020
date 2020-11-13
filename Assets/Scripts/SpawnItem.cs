using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
      public GameObject item;
    
      // the range of X
      [Header ("X Spawn Range")]
      public float xMin;
      public float xMax;
  
      // the range of y
      [Header ("Y Spawn Range")]
      public float yMin;
      public float yMax;
  
  
      void Start()
      {
        SpawnGoodies();
      }
  
      public void Update()
      {
             
      }
  
  
      void SpawnGoodies()
      {
          // Defines the min and max ranges for x and y
          Vector2 pos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
 
          // Creates the random object at the random 2D position.
          Instantiate (item, pos, transform.rotation);
      }
}
