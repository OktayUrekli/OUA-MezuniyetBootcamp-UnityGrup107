using UnityEngine;
using System.Collections.Generic;
public class MysticRunestone : MonoBehaviour
{
    public TreasureChest TreasureChest;
    private HashSet<string> collectedItems = new HashSet<string>();
    private bool playerInRange = false;
    [SerializeField] private Animator chestAnimator = null;
    [SerializeField] private int totalItems = 3;
    void Start()
    {
    }
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleChest();
        }
    }
    public bool AddItem(string itemID)
    {
        if (!collectedItems.Contains(itemID))
        {
            collectedItems.Add(itemID);
            if (collectedItems.Count >= totalItems)
            {
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    private void ToggleChest()
    {
        if (collectedItems.Count >= totalItems)
        {
            bool isTriggered = chestAnimator.GetBool("isTriggered");
            chestAnimator.SetBool("isTriggered", !isTriggered);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
