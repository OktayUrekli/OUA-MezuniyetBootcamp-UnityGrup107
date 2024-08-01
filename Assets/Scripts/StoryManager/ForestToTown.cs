using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestToTown : MonoBehaviour
{
    StoryManager storyManager;
    [SerializeField] GameObject textPanel;

    private void Start()
    {
        textPanel.SetActive(false);
    }


    public void YesForTravelButton()
    {
        PlayerPrefs.SetInt("Forest", 1);// orman görevi bitti
        Debug.Log("orman görevi bitti");
        SceneManager.LoadScene(2);
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
