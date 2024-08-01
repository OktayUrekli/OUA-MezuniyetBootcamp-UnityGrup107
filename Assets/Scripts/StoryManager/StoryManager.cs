using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI dutyText;

    string d1 = "Yerleþim yeri bul";
    string d2="Kasabayý araþtýr";
    string d3 = "Madenciyi bul";
    string d4 = "Terkedilmiþ zindana git";
    public string d5 = "Elmasý bul";
    string d6 = "Sisli kayalýklara git";
    public string d7 = "Yeteri kadar fosil topla";
     string d8 = "Demirciyi bul";
    string d9 = "Uzay gemisine geri dön";  
    public string d10 = "Kendi gezegenine geri dön";

    private void Start()
    {
        if (PlayerPrefs.GetInt("Forest")==0)
        {
            dutyText.text = d1;
        }
        else if (PlayerPrefs.GetInt("Forest") == 1 && PlayerPrefs.GetInt("Villager") == 0 )
        {
            dutyText.text = d2;
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Dungeon") == 1 && PlayerPrefs.GetInt("Fosil") == 0 && SceneManager.GetActiveScene().buildIndex==2)
        {
            dutyText.text = d6;
        }
        else if (PlayerPrefs.GetInt("Rocks") == 1 && PlayerPrefs.GetInt("Blacksmith") == 0)
        {
            dutyText.text = d8;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            dutyText.text = d10;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Villager")) 
        {
            dutyText.text = d3;
            Debug.Log("kasabalý ile görüþtüm");
            PlayerPrefs.SetInt("Villager", 1);// kasabalýya danýþtým
        }
        else if (collision.gameObject.CompareTag("Miner")&& PlayerPrefs.GetInt("Villager")== 1)
        {
            dutyText.text = d4;
            PlayerPrefs.SetInt("Miner", 1); //kasabalýdan sonra madenci ile konuþtum
            Debug.Log("madenci ile görüþtüm");
        }
        else if (collision.gameObject.CompareTag("Diamond"))
        {
            dutyText.text = d6;
            PlayerPrefs.SetInt("Diamond", 1);
            Debug.Log("elmasý aldým");
        }// zindana gittim elmasý aldým 
        else if (collision.gameObject.CompareTag("Fosil"))
        {
            dutyText.text = d8;
            PlayerPrefs.SetInt("Fosil", 1);
            Debug.Log("fosil topladým");
        }//kayalýklara gittim fosil topladým
        else if (collision.gameObject.CompareTag("Blacksmith")&& PlayerPrefs.GetInt("Rocks") == 1)
        {
            dutyText.text = d9;
            PlayerPrefs.SetInt("Blacksmith", 1); // demirci ile konuþtum
            Debug.Log("demirci ile konuþtum");
        }// artýk uzay gemisine gidebilirim
    }
    /*
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Villager"))
        {
            Debug.Log("kasabalý ile görüþtüm");
            PlayerPrefs.SetInt("Villager", 1);// kasabalýya danýþtým
        }
        else if (collision.gameObject.CompareTag("Miner") && PlayerPrefs.GetInt("Villager") == 1)
        {
            PlayerPrefs.SetInt("Miner", 1); //kasabalýdan sonra madenci ile konuþtum
            Debug.Log("madenci ile görüþtüm");
        }
        else if (collision.gameObject.CompareTag("Diamond"))
        {
            PlayerPrefs.SetInt("Diamond", 1);
            Debug.Log("elmasý aldým");
        }// zindana gittim elmasý aldým 
        else if (collision.gameObject.CompareTag("Fosil"))
        {
            PlayerPrefs.SetInt("fosil", 1);
            Debug.Log("fosil topladým");
        }//kayalýklara gittim fosil topladým
        else if (collision.gameObject.CompareTag("Blacksmith") && PlayerPrefs.GetInt("Rocks") == 1)
        {
            PlayerPrefs.SetInt("Blacksmith", 1); // demirci ile konuþtum
            Debug.Log("demirci ile konuþtum");
        }// artýk uzay gemisine gidebilirim
    }
    */
}
