using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int asteroidCount = 20;
    public float spawnRadius = 50f;

    void Start()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}
