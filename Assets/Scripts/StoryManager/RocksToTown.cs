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
        if (PlayerPrefs.GetInt("Fosil") == 1) // fosili topladýysam
        {
            PlayerPrefs.SetInt("Rocks", 1); //kayalýk görevi bitti
            Debug.Log("kayalýk görevi bitti");
            SceneManager.LoadScene(2); //kasabaya geri dönebilirim
 
        }
    }

    public void YesForTravelButton()
    {
        if (PlayerPrefs.GetInt("Fosil") == 1) // fosili topladýysam
        {
            PlayerPrefs.SetInt("Rocks", 1); //kayalýk görevi bitti
            Debug.Log("kayalýk görevi bitti");
            SceneManager.LoadScene(2); //kasabaya geri dönebilirim

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
