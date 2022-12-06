using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    TileSpawner tileSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] GameObject turretPrefab;
    [SerializeField] GameObject tankPrefab;
    [SerializeField] GameObject fuelPrefab;
    [SerializeField] float tallObstacleChance = 0.2f;
    [SerializeField] float turretSpawnChance;
    [SerializeField] float tankSpawnChance;
    [SerializeField] float fuelChance;
    [SerializeField] Transform fuelSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        tileSpawner = GameObject.FindObjectOfType<TileSpawner>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tileSpawner.SpawnTile(true);
            Destroy(gameObject, 2);
            GameManager.instance.speedincrease();
        }
    }

    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        float randomFuel = Random.Range(0f,50f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }
         
        if (random < turretSpawnChance)
        {
            obstacleToSpawn = turretPrefab;
        }
        if (random < tankSpawnChance)
        {
            obstacleToSpawn = tankPrefab;
        }

        if (randomFuel < fuelChance)
        {
            Instantiate(fuelPrefab, fuelSpawnPoint.position, Quaternion.identity, transform);
        }

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
}
