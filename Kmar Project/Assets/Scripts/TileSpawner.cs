using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileSpawner : MonoBehaviour
{
    public GameObject groundTile; 
    Vector3 nextSpawnPoint;       
    public void SpawnTile(bool spawnItems)
    {//spawns tile on the next spawnpoint
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {   //after 3 tiles opbstacles will be spawned
            temp.GetComponent<GroundTile>().SpawnObstacle();
        }
    }
    //for loop that spawns the tiles
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            if(i < 4)
            {
                //does not spawn obstacles for the first 3 tiles
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }
}
