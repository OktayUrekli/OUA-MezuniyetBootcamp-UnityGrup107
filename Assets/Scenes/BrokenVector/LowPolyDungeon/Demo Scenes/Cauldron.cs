using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public GameObject diamond;
    private int currentOrder = 1;

    void Start()
    {
        diamond.SetActive(false);
    }

    public bool AddItem(int order)
    {
        if (order == currentOrder)
        {
            currentOrder++;
            if (currentOrder > 3)
            {
                diamond.SetActive(true);
            }
            return true;
        }
        else
        {
            Debug.Log("Wrong order!");
            return false;
        }
    }
}
