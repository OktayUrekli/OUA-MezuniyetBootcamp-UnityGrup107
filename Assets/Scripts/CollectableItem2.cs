using UnityEngine;
public enum ItemType2
{
    CauldronItem,
    MysticItem
}
class CollectibleItem2 : MonoBehaviour
{
    public ItemType itemType;
    public string itemID;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (itemType == ItemType.MysticItem)
            {
                GameManager3.instance.mysticStoneInteractionCount++;
                if (!string.IsNullOrEmpty(itemID))
                {
                    if (GameObject.FindObjectOfType<MysticRunestone>().AddItem(itemID))
                    {
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    Debug.LogError("MysticItem requires a unique itemID!");
                }
            }
        }
    }

    
}
