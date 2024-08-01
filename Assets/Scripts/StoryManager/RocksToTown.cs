using UnityEngine;
using UnityEngine.SceneManagement;

public class RocksToTown : MonoBehaviour
{
    StoryManager storyManager;
    [SerializeField] GameObject textPanel;

    private void Start()
    {
        textPanel.SetActive(false);
    }


    public void TravelButton()
    {
        if (PlayerPrefs.GetInt("Fosil") == 1) // fosili toplad�ysam
        {
            PlayerPrefs.SetInt("Rocks", 1); //kayal�k g�revi bitti
            Debug.Log("kayal�k g�revi bitti");
            SceneManager.LoadScene(2); //kasabaya geri d�nebilirim
 
        }
    }

    public void YesForTravelButton()
    {
        if (PlayerPrefs.GetInt("Fosil") == 1) // fosili toplad�ysam
        {
            PlayerPrefs.SetInt("Rocks", 1); //kayal�k g�revi bitti
            Debug.Log("kayal�k g�revi bitti");
            SceneManager.LoadScene(2); //kasabaya geri d�nebilirim

        }
    }

    public void NoForTravelButton()
    {
        textPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            storyManager = other.gameObject.GetComponent<StoryManager>();
            textPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            textPanel.SetActive(false);
        }
    }
}
