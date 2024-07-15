using UnityEngine;
using System.Collections;

public class planetScaler : MonoBehaviour
{
    public float maxScale = 100f; // Maximum scale of the planet

    void Start()
    {
        // Set initial scale of the planet
        transform.localScale = Vector3.one; // Assuming the planet starts at scale 1

        // Start scaling coroutine
        StartCoroutine(ScalePlanetOverTime());
    }

    IEnumerator ScalePlanetOverTime()
    {
        float timer = 0f;
        float duration = 60f; // Scale over 60 seconds

        while (timer < duration)
        {
            timer += Time.deltaTime;

            // Calculate scale factor based on current time remaining
            float timeRatio = timer / duration;
            float scaleFactor = Mathf.Lerp(1f, maxScale, timeRatio);

            // Apply scale to the planet object
            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f); // Assuming the planet is on XY plane

            yield return null;
        }

        // Ensure final scale is maxScale
        transform.localScale = new Vector3(maxScale, maxScale, 1f); // Assuming the planet is on XY plane
    }
}
