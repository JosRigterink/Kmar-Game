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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        //tileSpawner.MoveTile();
        Destroy(gameObject, 2);
    }
}
