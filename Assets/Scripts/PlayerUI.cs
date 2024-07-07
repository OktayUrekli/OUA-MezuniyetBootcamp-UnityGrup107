using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    // Reference to the hearts (4 in total)
    public Image[] hearts;

    // Sprites for full, half, and empty hearts
    public Sprite fullHeartSprite;
    public Sprite halfHeartSprite;
    public Sprite emptyHeartSprite;

    private float maxHealth = 100f;

    void Start()
    {
        UpdateHearts(maxHealth);
    }

    public void UpdateHealthUI(float currentHealth)
    {
        UpdateHearts(currentHealth);
    }
    void UpdateHearts(float currentHealth)
    {
        float healthPerHeart = maxHealth / hearts.Length;

        for (int i = 0; i < hearts.Length; i++)
        {
            float heartValue = healthPerHeart * (i + 1);

            if (currentHealth >= heartValue)
            {
                // Full heart
                hearts[i].sprite = fullHeartSprite;
            }
            else if (currentHealth >= heartValue - (healthPerHeart / 2))
            {
                // Half heart
                hearts[i].sprite = halfHeartSprite;
            }
            else
            {
                // Empty heart
                hearts[i].sprite = emptyHeartSprite;
            }
        }
    }
}