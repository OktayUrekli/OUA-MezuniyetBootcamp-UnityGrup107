using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int maxAsteroids = 5;
    public float spawnRadius = 50f;
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
            yield return new WaitForSeconds(checkInterval);
            maxAsteroids = Random.Range(1, maxAsteroidsCap + 1);
            asteroids.RemoveAll(asteroid => asteroid == null);
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
    Vector3 GetRandomPositionNearSpawner()
    {
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection.z = 0;
        Vector3 spawnPosition = transform.position + randomDirection;
        return spawnPosition;
    }
}
