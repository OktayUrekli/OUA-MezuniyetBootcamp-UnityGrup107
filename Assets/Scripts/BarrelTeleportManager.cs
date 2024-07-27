using UnityEngine;
using UnityEngine.SceneManagement;


public class BarrelTeleportManager : MonoBehaviour
{
    [SerializeField] Transform lastTravelPoint;
    [SerializeField] int travelSceneIndex;
    [SerializeField] GameObject travelText;

    void Start()
    {
        travelText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            travelText.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            travelText.SetActive(false);
        }
    }


    public void YesForTravel()
    {
        SceneManager.LoadScene(travelSceneIndex);
    }

    public void NoForTravel()
    {
        travelText.SetActive(false);
    }
}
