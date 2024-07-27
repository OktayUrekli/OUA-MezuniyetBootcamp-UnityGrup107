using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20f; // Speed of the bullet

    private Rigidbody rb;
    public bool canShoot = true; // Flag to allow shooting

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        // Check if shooting is allowed (not in win or lose state)
        if (canShoot)
        {
            // Movement
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb.velocity = movement * speed;

            // Shooting
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            //reset the velocity to zero when shooting is disabled
            rb.velocity = Vector3.zero;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Calculate direction towards asteroids
        Vector3 direction = (bulletSpawn.position - transform.position).normalized;

        // Apply velocity to the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = direction * bulletSpeed;
    }

    // Method to disable shooting (called when game is in win or lose state)
    public void DisableShooting()
    {
        canShoot = false;
    }

    // Method to enable shooting (called when restarting or returning to main menu)
    public void EnableShooting()
    {
        canShoot = true;
    }
}
