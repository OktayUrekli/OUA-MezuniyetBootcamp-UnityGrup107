using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damageAmount = 20f; // Amount of damage the trap will inflict
    public float damageInterval = 1f; // Time interval between consecutive damages

    private bool playerInRange = false; // Track if the player is in range of the trap
    private float timeSinceLastDamage = 0f; // Timer to handle damage intervals

    private void Update()
    {
        if (playerInRange)
        {
            // Increment timer
            timeSinceLastDamage += Time.deltaTime;

            // Check if enough time has passed to apply damage
            if (timeSinceLastDamage >= damageInterval)
            {
                ApplyDamage();
                timeSinceLastDamage = 0f; // Reset the timer
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // Player has entered the trap's range
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Player has exited the trap's range
        }
    }

    private void ApplyDamage()
    {
        PlayerController1 playerController = FindObjectOfType<PlayerController1>();

        if (playerController != null)
        {
            playerController.TakeDamage(damageAmount); // Apply damage to the player
        }
    }
}
