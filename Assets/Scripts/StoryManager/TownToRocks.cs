using UnityEngine;
using UnityEngine.SceneManagement;

public class TownToRocks : MonoBehaviour
{
    StoryManager storyManager ;
    [SerializeField] GameObject textPanel;

    private void Start()
    {
        
        textPanel.SetActive(false);
    }

    public void YesForTravelButton()
    {
        if (PlayerPrefs.GetInt("Dungeon") == 1) // e�er zindan� bitirdiysem 
        {
            Debug.Log("kayal�klara gittim");
            SceneManager.LoadScene(4);// kayal�klara gidebilirim
            storyManager.dutyText.text = storyManager.d7;
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
