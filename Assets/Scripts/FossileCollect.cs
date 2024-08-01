using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FossilCollect : MonoBehaviour
{
    public int fossilsRequired = 10; // Number of fossils required to complete the quest
    public TextMeshProUGUI fossilCountText; // UI Text to display the fossil count
    public static bool fossilCollectQuestCompleted = false; // Static variable to indicate quest completion
    private int collectedFossils = 0; // Current number of collected fossils
    public float spinSpeed = 30f;

    private void Start()
    {
        UpdateFossilCountUI(); // Initialize the UI with the starting count
    }

    private void Update() 
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectFossil();
        }
    }

    private void CollectFossil()
    {
        collectedFossils++; // Increment the fossil count

        // Check if the required number of fossils has been collected
        if (collectedFossils >= fossilsRequired)
        {
            QuestComplete(); // Complete the quest
        }

        UpdateFossilCountUI(); // Update the UI to reflect the new count
        Destroy(gameObject); // Destroy the fossil collectable
    }

    private void UpdateFossilCountUI()
    {
        if (fossilCountText != null)
        {
            fossilCountText.text = $"{collectedFossils}/{fossilsRequired}";
        }
    }

    private void QuestComplete()
    {
        fossilCollectQuestCompleted = true; // Set the quest completion flag to true
        Debug.Log("Quest Completed! All fossils collected.");
        // Add any additional logic for quest completion here, such as unlocking rewards
    }
}
