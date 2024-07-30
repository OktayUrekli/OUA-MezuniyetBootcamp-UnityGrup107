using UnityEngine;
public class ShipController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20f;
    private Rigidbody rb;
    public bool canShoot = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void Update()
    {
        if (canShoot)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb.velocity = movement * speed;
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Vector3 direction = (bulletSpawn.position - transform.position).normalized;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = direction * bulletSpeed;
    }
    public void DisableShooting()
    {
        canShoot = false;
    }
    public void EnableShooting()
    {
        canShoot = true;
    }
}
