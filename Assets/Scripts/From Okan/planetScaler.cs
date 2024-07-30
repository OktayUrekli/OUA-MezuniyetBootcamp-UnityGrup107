using UnityEngine;
using System.Collections;
public class planetScaler : MonoBehaviour
{
    public float maxScale = 100f;
    void Start()
    {
        transform.localScale = Vector3.one;
        StartCoroutine(ScalePlanetOverTime());
    }
    IEnumerator ScalePlanetOverTime()
    {
        float timer = 0f;
        float duration = 60f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float timeRatio = timer / duration;
            float scaleFactor = Mathf.Lerp(1f, maxScale, timeRatio);
            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
            yield return null;
        }
        transform.localScale = new Vector3(maxScale, maxScale, 1f);
    }
}
