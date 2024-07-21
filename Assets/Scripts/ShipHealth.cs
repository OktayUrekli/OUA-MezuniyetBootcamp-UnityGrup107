using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the player
    private int currentHealth; // Current health of the player
    public Slider shipHealth; // Reference to the health slider UI
    public TextMeshProUGUI healthText; // Reference to the health text UI
    public GameObject loseImage; // Reference to the "Lose" image
    public ShipController shipController; // Reference to the ShipController script for shooting control

    void Start()
    {
        currentHealth = maxHealth;
        shipHealth.maxValue = maxHealth;
        shipHealth.value = currentHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        shipHealth.value = currentHealth;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    }

    void Die()
    {
        // Show the "Lose" image
        loseImage.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;

        // Disable shooting by setting canShoot to false in ShipController
        shipController.canShoot = false;
    }
}
