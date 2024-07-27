using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerController = other.GetComponent<PlayerMovement>();
            if (playerController != null && playerController.hasKey)
            {
                myDoor.SetBool("isKeyCollected", true);

                if (openTrigger)
                {
                    myDoor.SetBool("Open", true);
                    myDoor.SetBool("Close", false);
                    gameObject.SetActive(false);
                }
                else if (closeTrigger)
                {
                    myDoor.SetBool("Open", false);
                    myDoor.SetBool("Close", true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
