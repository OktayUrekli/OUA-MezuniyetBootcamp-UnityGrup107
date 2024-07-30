using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShipHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider shipHealth;
    public TextMeshProUGUI healthText;
    public GameObject loseImage;
    public ShipController shipController;
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
        loseImage.SetActive(true);
        Time.timeScale = 0f;
        shipController.canShoot = false;
    }
}
