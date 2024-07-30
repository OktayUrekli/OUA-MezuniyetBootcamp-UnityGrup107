using UnityEngine;
public class Asteroid : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 10f;
    private float spawnTime;
    void Start()
    {
        spawnTime = Time.time;
    }
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (Time.time - spawnTime > lifetime)
        {
            Destroy(gameObject);
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
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
