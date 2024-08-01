using UnityEngine;
using UnityEngine.SceneManagement;

public class TownToForest : MonoBehaviour
{
    StoryManager storyManager;
    [SerializeField] GameObject textPanel;

    private void Start()
    {
        
        textPanel.SetActive(false);
    }



    public void YesForTravelButton()
    {
        if (PlayerPrefs.GetInt("Blacksmith") == 1) // demirci ile g�r��t�ysem
        {
            Debug.Log("uzay gemisine geri d�nd�m");
            SceneManager.LoadScene(5); // uzay gemisine geri d�nebilirim
            storyManager.dutyText.text = storyManager.d10;
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
            storyManager=other.gameObject.GetComponent<StoryManager>();
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
