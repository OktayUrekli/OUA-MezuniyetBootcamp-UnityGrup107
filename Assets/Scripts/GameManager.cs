using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TreasureChest treasureChest;
    private HashSet<string> collectedItemsForMysticStone = new HashSet<string>();
    private bool isNearMysticStone = false;
    public int mysticStoneInteractionCount = 0;
    public Transform mystical;
    private ThirdPersonController playerController;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        playerController = FindObjectOfType<ThirdPersonController>();
    }
    public void CollectItemForMysticStone(string itemID)
    {
        if (!collectedItemsForMysticStone.Contains(itemID))
        {
            collectedItemsForMysticStone.Add(itemID);
        }
    }
    public void SetNearMysticStone(bool isNear)
    {
        isNearMysticStone = isNear;
        if (!isNear)
        {
            mysticStoneInteractionCount = 0;
        }
    }
    void Update()
    {
        if (mysticStoneInteractionCount >= 3 && Input.GetKeyDown(KeyCode.E))
        {
            if (playerController != null && Vector3.Distance(mystical.transform.position, playerController.transform.position) < 5f)
            {
                OpenTreasureChest();
                mysticStoneInteractionCount = 0;
            }
        }
    }
    public bool HasCollectedAllItemsForMysticStone()
    {
        return collectedItemsForMysticStone.Count >= 3;
    }
    private void OpenTreasureChest()
    {
        treasureChest.OpenChest();
    }
}
