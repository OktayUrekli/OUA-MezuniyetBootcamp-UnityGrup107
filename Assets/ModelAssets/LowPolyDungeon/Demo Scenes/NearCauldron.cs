using UnityEngine;

public class NearCauldron : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager2.instance.SetNearCauldron(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager2.instance.SetNearCauldron(false);
        }
    }
}
