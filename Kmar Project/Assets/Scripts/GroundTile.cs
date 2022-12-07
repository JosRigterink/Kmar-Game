using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] Transform fuelSpawnPoint;
    TileSpawner tileSpawner;

    [Header("TileContent")]
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] GameObject turretPrefab;
    [SerializeField] GameObject tankPrefab;
    [SerializeField] GameObject fuelPrefab;
    
    [Header("SpawnChances")]
    [SerializeField] float tallObstacleChance = 0.2f;
    [SerializeField] float turretSpawnChance;
    [SerializeField] float tankSpawnChance;
    [SerializeField] float fuelChance;

    void Start()
    {//search for tilespawner
        tileSpawner = GameObject.FindObjectOfType<TileSpawner>();
    }
    private void OnTriggerExit(Collider other)
    {
        //if player leaves a tile a new tile is spawned and the last tile will get deleted
        if (other.gameObject.tag == "Player")
        {
            tileSpawner.SpawnTile(true);
            Destroy(gameObject, 2);
        }
    }

    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f); //gets a random number between 0 and 1
        float randomFuel = Random.Range(0f,50f); //gets a randomfuel number between 0 and 50
        if (random < tallObstacleChance)
        {
            //if the random number is less then tallObstacleChance the obstacle that will be spawned is tallobstacle 
            obstacleToSpawn = tallObstaclePrefab;
        }
         
        if (random < turretSpawnChance)
        {
            //if the random number is less then turretSpawnChance the obstacle that will be spawned is turret 
            obstacleToSpawn = turretPrefab;
        }
        if (random < tankSpawnChance)
        {
            //if the random number is less then tankSpawnChance the obstacle that will be spawned is tankturret
            obstacleToSpawn = tankPrefab;
        }

        if (randomFuel < fuelChance)
        {
            //if the randomFuel number is less then fuelChance a fuel orb will be spawned
            Instantiate(fuelPrefab, fuelSpawnPoint.position, Quaternion.identity, transform);
        }
        //gets random location
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
}
