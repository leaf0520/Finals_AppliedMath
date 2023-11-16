using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform obstacleSpawnPoint;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);

       
        InvokeRepeating("ChangeDifficulty", 10f, 20f);
    }

    void ChangeDifficulty()
    {

        spawnInterval *= 0.9f;
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, obstacleSpawnPoint.position, Quaternion.identity);
    }
}

