using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.ResetToStartPosition();
            }
        }
    }
}
