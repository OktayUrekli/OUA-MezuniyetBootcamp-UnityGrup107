using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int maxAsteroids = 5;
    public float spawnDistance = 50f;
    public float checkInterval = 1f;
    public int maxAsteroidsCap = 5;

    private Transform playerTransform;
    private Camera mainCamera;
    private List<GameObject> asteroids = new List<GameObject>();

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        mainCamera = Camera.main;

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
        Vector3 spawnPosition = GetRandomPositionInView();

        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        asteroids.Add(newAsteroid);
    }

    //To get them spawn in camera view
    Vector3 GetRandomPositionInView()
    {
        Vector3 viewportPosition = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), spawnDistance);

        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        return worldPosition;
    }
}
