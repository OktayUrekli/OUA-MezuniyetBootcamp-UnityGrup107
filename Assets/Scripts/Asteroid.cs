using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 5f; // Speed of the asteroid movement
    public float lifetime = 10f; // Time in seconds before the asteroid is destroyed

    private float spawnTime;

    void Start()
    {
        // Record the time when the asteroid is spawned
        spawnTime = Time.time;
    }

    void Update()
    {
        // Move the asteroid in the negative z-direction
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Check if the asteroid has exceeded its lifetime
        if (Time.time - spawnTime > lifetime)
        {
            Destroy(gameObject); // Destroy the asteroid
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShipHealth shipHealth = collision.gameObject.GetComponent<ShipHealth>();
            if (shipHealth != null)
            {
                shipHealth.TakeDamage(10);
            }

            Destroy(gameObject); // Destroy the asteroid
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Destroy the bullet
            Destroy(gameObject); // Destroy the asteroid
        }
    }
}
