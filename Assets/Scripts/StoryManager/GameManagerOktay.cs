using UnityEngine;

public class GameManagerOktay : MonoBehaviour
{

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Forest"))
        {
            PlayerPrefs.SetInt("Forest", 0);
        }
        if (!PlayerPrefs.HasKey("Villager"))
        {
            PlayerPrefs.SetInt("Villager", 0);
        }
        if (!PlayerPrefs.HasKey("Blacksmith"))
        {
            PlayerPrefs.SetInt("Blacksmith", 0);
        }
        if (!PlayerPrefs.HasKey("Miner"))
        {
            PlayerPrefs.SetInt("Miner", 0);
        }
        if (!PlayerPrefs.HasKey("Dungeon"))
        {
            PlayerPrefs.SetInt("Dungeon", 0);
        }
        if (!PlayerPrefs.HasKey("Diamond"))
        {
            PlayerPrefs.SetInt("Diamond", 0);
        }
        if (!PlayerPrefs.HasKey("Rocks"))
        {
            PlayerPrefs.SetInt("Rocks", 0);
        }
        if (!PlayerPrefs.HasKey("Fosil"))
        {
            PlayerPrefs.SetInt("Fosil", 0);
        }

    }

    
}
