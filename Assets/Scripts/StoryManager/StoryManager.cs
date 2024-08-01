using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI dutyText;

    string d1 = "Yerle�im yeri bul";
    string d2="Kasabay� ara�t�r";
    string d3 = "Madenciyi bul";
    string d4 = "Terkedilmi� zindana git";
    public string d5 = "Elmas� bul";
    string d6 = "Sisli kayal�klara git";
    public string d7 = "Yeteri kadar fosil topla";
     string d8 = "Demirciyi bul";
    string d9 = "Uzay gemisine geri d�n";  
    public string d10 = "Kendi gezegenine geri d�n";

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
            Debug.Log("kasabal� ile g�r��t�m");
            PlayerPrefs.SetInt("Villager", 1);// kasabal�ya dan��t�m
        }
        else if (collision.gameObject.CompareTag("Miner")&& PlayerPrefs.GetInt("Villager")== 1)
        {
            dutyText.text = d4;
            PlayerPrefs.SetInt("Miner", 1); //kasabal�dan sonra madenci ile konu�tum
            Debug.Log("madenci ile g�r��t�m");
        }
        else if (collision.gameObject.CompareTag("Diamond"))
        {
            dutyText.text = d6;
            PlayerPrefs.SetInt("Diamond", 1);
            Debug.Log("elmas� ald�m");
        }// zindana gittim elmas� ald�m 
        else if (collision.gameObject.CompareTag("Fosil"))
        {
            dutyText.text = d8;
            PlayerPrefs.SetInt("Fosil", 1);
            Debug.Log("fosil toplad�m");
        }//kayal�klara gittim fosil toplad�m
        else if (collision.gameObject.CompareTag("Blacksmith")&& PlayerPrefs.GetInt("Rocks") == 1)
        {
            dutyText.text = d9;
            PlayerPrefs.SetInt("Blacksmith", 1); // demirci ile konu�tum
            Debug.Log("demirci ile konu�tum");
        }// art�k uzay gemisine gidebilirim
    }
    /*
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Villager"))
        {
            Debug.Log("kasabal� ile g�r��t�m");
            PlayerPrefs.SetInt("Villager", 1);// kasabal�ya dan��t�m
        }
        else if (collision.gameObject.CompareTag("Miner") && PlayerPrefs.GetInt("Villager") == 1)
        {
            PlayerPrefs.SetInt("Miner", 1); //kasabal�dan sonra madenci ile konu�tum
            Debug.Log("madenci ile g�r��t�m");
        }
        else if (collision.gameObject.CompareTag("Diamond"))
        {
            PlayerPrefs.SetInt("Diamond", 1);
            Debug.Log("elmas� ald�m");
        }// zindana gittim elmas� ald�m 
        else if (collision.gameObject.CompareTag("Fosil"))
        {
            PlayerPrefs.SetInt("fosil", 1);
            Debug.Log("fosil toplad�m");
        }//kayal�klara gittim fosil toplad�m
        else if (collision.gameObject.CompareTag("Blacksmith") && PlayerPrefs.GetInt("Rocks") == 1)
        {
            PlayerPrefs.SetInt("Blacksmith", 1); // demirci ile konu�tum
            Debug.Log("demirci ile konu�tum");
        }// art�k uzay gemisine gidebilirim
    }
    */
}
