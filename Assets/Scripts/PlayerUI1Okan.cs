using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIOkan : MonoBehaviour
{
    public Image healthBar;  // The Image component of the health bar's fill
    public TextMeshProUGUI healthText;  // The Text component to display health

    private PlayerController2 playerController;

    void Start()
    {
        playerController = UnityEngine.Object.FindFirstObjectByType<PlayerController2>();
        if (playerController != null)
        {
            UpdateHealthUI(); // Initialize health UI
        }
    }

    void Update()
    {
        if (playerController != null)
        {
            UpdateHealthUI(); // Continuously update health UI
        }
    }

    // Public method to update the health UI
    public void UpdateHealthUI()
    {
        if (playerController == null)
            return;

        float currentHealth = playerController.PlayerHealth;
        float maxHealth = playerController.MaxPlayerHealth;

        if (healthBar != null)
        {
            // Update the fill amount of the health bar
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        if (healthText != null)
        {
            // Update the health text
            healthText.text = $"{currentHealth:0}/{maxHealth:0}";
        }
    }
}
