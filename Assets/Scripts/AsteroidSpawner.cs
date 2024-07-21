using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int maxAsteroids = 5;
    public float spawnRadius = 50f; // Radius around the spawner where asteroids will spawn
    public float checkInterval = 1f;
    public int maxAsteroidsCap = 5;

    private List<GameObject> asteroids = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(checkInterval);

            // Randomly change the maxAsteroids value with a cap
            maxAsteroids = Random.Range(1, maxAsteroidsCap + 1);

            // Remove any null entries from the asteroids list (in case asteroids have been destroyed)
            asteroids.RemoveAll(asteroid => asteroid == null);

            // Check the current number of asteroids and spawn new ones if needed
            while (asteroids.Count < maxAsteroids)
            {
                SpawnAsteroid();
            }
        }
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPosition = GetRandomPositionNearSpawner();
        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        asteroids.Add(newAsteroid);
    }

    // Get a random position near the spawner object within the spawn radius
    Vector3 GetRandomPositionNearSpawner()
    {
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection.z = 0; // Ensure the z-coordinate is zero for 2D games
        Vector3 spawnPosition = transform.position + randomDirection;
        return spawnPosition;
    }
}
