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
    [SerializeField] float tallObstacleChance = 0.2f;
    [SerializeField] float turretSpawnChance;
    [SerializeField] float tankSpawnChance;

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

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
}
