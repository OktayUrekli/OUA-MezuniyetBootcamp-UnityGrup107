using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f; // Total time in seconds
    private float remainingTime; // Remaining time in seconds
    public Slider timerSlider; // Reference to the timer slider UI
    public TextMeshProUGUI timerText; // Reference to the timer text UI
    public GameObject winImage; // Reference to the "Win" image
    public GameObject loseImage; // Reference to the "Lose" image
    public planetScaler planetScaler; // Reference to the planetScaler script for scaling the planet

    void Start()
    {
        remainingTime = totalTime;
        timerSlider.maxValue = totalTime;
        timerSlider.value = remainingTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerSlider.value = remainingTime;
            UpdateTimerText();

            if (remainingTime <= 0)
            {
                TimeUp();
            }
        }
    }

    void UpdateTimerText()
    {
        timerText.text = Mathf.CeilToInt(remainingTime).ToString();
    }

    void TimeUp()
    {
        // Show the "Win" image
        winImage.SetActive(true);

        // Calculate scaling speed factor based on initial total time
        float scalingSpeedFactor = totalTime / 60f; 

        // Scale the planet to max scale over a period of 5 seconds
        StartCoroutine(ScalePlanetOverTime(5f, scalingSpeedFactor));

        // Pause the game
        Time.timeScale = 0f;
    }

    IEnumerator ScalePlanetOverTime(float duration, float scalingSpeedFactor)
    {
        float timer = 0f;
        float startScale = planetScaler.transform.localScale.x;
        float endScale = planetScaler.maxScale;

        while (timer < duration)
        {
            timer += Time.deltaTime * scalingSpeedFactor; // Scale time by speed factor
            float t = Mathf.Clamp01(timer / duration);
            float scale = Mathf.Lerp(startScale, endScale, t);
            planetScaler.transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

        planetScaler.transform.localScale = new Vector3(endScale, endScale, endScale);
    }
}
