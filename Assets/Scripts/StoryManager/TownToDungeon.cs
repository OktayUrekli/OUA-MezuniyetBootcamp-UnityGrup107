using UnityEngine;
using UnityEngine.SceneManagement;

public class TownToDungeon : MonoBehaviour
{
    StoryManager storyManager;
    [SerializeField] GameObject textPanel;

    private void Start()
    {
        
        textPanel.SetActive(false);
    }



    public void YesForTravelButton()
    {
        if (PlayerPrefs.GetInt("Miner") == 1) // madenci ile konuþtuysam
        {
            Debug.Log("Zindana gittim");
            SceneManager.LoadScene(3); // zindana gidebilirim
            storyManager.dutyText.text = storyManager.d5;

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

