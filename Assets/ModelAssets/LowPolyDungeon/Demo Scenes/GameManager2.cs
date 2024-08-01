using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;
    public Cauldron cauldron;

    private Queue<int> collectedItems = new Queue<int>();
    private bool isNearCauldron = false;
    private int nextOrder = 1;

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
    }

    public bool CanCollectItem(int order)
    {
        return order == nextOrder;
    }

    public void CollectItem(CollectibleItem item)
    {
        collectedItems.Enqueue(item.order);
        nextOrder++;
    }

    public void PlaceItemInCauldron()
    {
        if (isNearCauldron && collectedItems.Count > 0)
        {
            int itemOrder = collectedItems.Peek();
            if (cauldron.AddItem(itemOrder))
            {
                collectedItems.Dequeue();
            }
        }
    }

    public void SetNearCauldron(bool isNear)
    {
        isNearCauldron = isNear;
    }

    public void CollectDiamond()
    {
        Debug.Log("Game over!");
        Application.Quit();
    }
}
