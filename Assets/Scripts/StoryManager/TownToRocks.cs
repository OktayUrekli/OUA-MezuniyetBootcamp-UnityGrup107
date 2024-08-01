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
        if (PlayerPrefs.GetInt("Dungeon") == 1) // eðer zindaný bitirdiysem 
        {
            Debug.Log("kayalýklara gittim");
            SceneManager.LoadScene(4);// kayalýklara gidebilirim
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
