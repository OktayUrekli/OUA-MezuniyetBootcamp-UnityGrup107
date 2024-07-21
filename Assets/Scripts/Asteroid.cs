using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 5f;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
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

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Destroy the bullet
            Destroy(gameObject); // Destroy the asteroid
        }
    }
}
