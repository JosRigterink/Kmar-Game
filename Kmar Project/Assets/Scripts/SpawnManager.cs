using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    TileSpawner tileSpawner;
    void Start()
    {
        tileSpawner = GetComponent<TileSpawner>(); 
    }

    //oldscript

    public void SpawnTriggerEntered()
    {
        //destroys tile after 2 seconds
        //Destroy(gameObject, 2);
    }
}
