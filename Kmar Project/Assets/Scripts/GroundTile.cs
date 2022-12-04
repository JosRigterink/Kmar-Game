using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    TileSpawner tileSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        tileSpawner = GameObject.FindObjectOfType<TileSpawner>();
        SpawnObstacle();
    }
    private void OnTriggerExit(Collider other)
    {
        tileSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
            obstacleToSpawn = tallObstaclePrefab;

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
}
