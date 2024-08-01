using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    public float healAmount = 20f; // Amount of health restored when collected
    private bool hasBeenCollected = false; // To prevent multiple pickups
    public float spinSpeed = 30f; // Speed of the spinning effect

    private void Update()
    {
        // Rotate the object around its Y-axis
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenCollected)
        {
            PlayerController1 playerController = other.GetComponent<PlayerController1>();
            if (playerController != null)
            {
                playerController.Heal(healAmount); // Heal the player
                hasBeenCollected = true; // Mark as collected
                Destroy(gameObject); // Destroy the health item
            }
        }
    }
}
