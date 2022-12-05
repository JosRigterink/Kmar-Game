using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    TileSpawner tileSpawner;
    // Start is called before the first frame update
    void Start()
    {
        tileSpawner = GetComponent<TileSpawner>(); 
    }

    public void SpawnTriggerEntered()
    {
        Destroy(gameObject, 2);
    }
}
