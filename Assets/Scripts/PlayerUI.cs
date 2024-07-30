using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public Image[] hearts;
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
                hearts[i].sprite = fullHeartSprite;
            }
            else if (currentHealth >= heartValue - (healthPerHeart / 2))
            {
                hearts[i].sprite = halfHeartSprite;
            }
            else
            {
                hearts[i].sprite = emptyHeartSprite;
            }
        }
    }
}
