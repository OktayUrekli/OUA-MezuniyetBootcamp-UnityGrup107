using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f; 
    private float remainingTime;
    public Slider timerSlider;
    public TextMeshProUGUI timerText;

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
        Debug.Log("Time's up!");
    }
}
