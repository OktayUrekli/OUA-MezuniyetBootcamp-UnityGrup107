using UnityEngine;

public class Diamond : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectDiamond();
            gameObject.SetActive(false);
        }
    }
}
