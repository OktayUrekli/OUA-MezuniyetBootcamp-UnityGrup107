using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class planetScaler : MonoBehaviour
{
    public float maxScale = 100f; // Maximum scale of the planet
    public Slider timerSlider; // Reference to the TimerSlider UI component

    private float initialScale; // Initial scale of the planet
    private float scaleDuration = 60f; // Duration in seconds to reach max scale

    void Start()
    {
        // Get initial time remaining from TimerSlider (assuming normalized 0 to 1)
        float initialTimeRemaining = 1f - timerSlider.value;

        // Calculate initial scale based on initial time remaining
        initialScale = Mathf.Lerp(1f, maxScale, initialTimeRemaining);

        // Set initial scale of the planet
        transform.localScale = new Vector3(initialScale, initialScale, 1f); // Assuming the planet is on XY plane

        // Start scaling coroutine
        StartCoroutine(ScalePlanetOverTime());
    }

    IEnumerator ScalePlanetOverTime()
    {
        float timer = 0f;

        while (timer < scaleDuration)
        {
            timer += Time.deltaTime;

            // Calculate scale factor based on current time remaining
            float timeRatio = timer / scaleDuration;
            float scaleFactor = Mathf.Lerp(initialScale, maxScale, timeRatio);

            // Apply scale to the planet object
            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f); // Assuming the planet is on XY plane

            yield return null;
        }

        // Ensure final scale is maxScale
        transform.localScale = new Vector3(maxScale, maxScale, 1f); // Assuming the planet is on XY plane
    }
}
