using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f;
    private float remainingTime;
    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    public GameObject winImage;
    public GameObject loseImage;
    public planetScaler planetScaler;
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
        winImage.SetActive(true);
        float scalingSpeedFactor = totalTime / 60f;
        StartCoroutine(ScalePlanetOverTime(5f, scalingSpeedFactor));
        Time.timeScale = 0f;
    }
    IEnumerator ScalePlanetOverTime(float duration, float scalingSpeedFactor)
    {
        float timer = 0f;
        float startScale = planetScaler.transform.localScale.x;
        float endScale = planetScaler.maxScale;
        while (timer < duration)
        {
            timer += Time.deltaTime * scalingSpeedFactor;
            float t = Mathf.Clamp01(timer / duration);
            float scale = Mathf.Lerp(startScale, endScale, t);
            planetScaler.transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }
        planetScaler.transform.localScale = new Vector3(endScale, endScale, endScale);
    }
}
