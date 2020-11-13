using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject item;
    private Transform player;

    // Gets the position of the player
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //Spawns in the dropped item
    public void SpawnDroppedItem()
    {
        Vector2 playerpos = new Vector2(player.position.x, player.position.y - 1);
        Instantiate(item, playerpos, Quaternion.identity);
    }
}
