using UnityEngine;

public class Diamond : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager2.instance.CollectDiamond();
            gameObject.SetActive(false);
        }
    }
}
