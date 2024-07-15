using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public float bulletSpeed = 20f; // Adjust as needed
    public float lifespan = 5f;     // Lifespan of the bullet in seconds

    void Start()
    {
        // Set initial velocity
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;

        // Destroy the bullet after its lifespan
        Destroy(gameObject, lifespan);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if collided with an asteroid
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Vurdu");
            // Destroy the asteroid
            Destroy(collision.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
