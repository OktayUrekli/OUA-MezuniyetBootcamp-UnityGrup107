using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public float bulletSpeed = 10f; // Adjust as needed

    void Start()
    {
        // Set initial velocity
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if collided with an asteroid
        if (other.CompareTag("Asteroid"))
        {
            // Destroy the asteroid
            Destroy(other.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
