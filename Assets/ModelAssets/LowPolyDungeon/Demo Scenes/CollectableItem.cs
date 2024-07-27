using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public int order;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.CanCollectItem(order))
            {
                GameManager.instance.CollectItem(this);
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("You tried to collect the object in the wrong order!");
            }
        }
    }
}
