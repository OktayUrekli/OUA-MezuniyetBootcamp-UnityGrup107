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
        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Set initial velocity for the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.useGravity = false;

        // Ensure the bullet's forward direction is aligned with its movement direction
        bullet.transform.forward = bulletSpawn.forward;
        bulletRb.velocity = bulletSpawn.forward * bulletSpeed;

        Debug.Log("Bullet Velocity: " + bulletRb.velocity);
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
