using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeverTrigger : MonoBehaviour
{
    private bool playerInRange = false;
    [SerializeField] private Animator leverAnimator = null;
    [SerializeField] private Animator trapDoorAnimator = null;
    [SerializeField] private int leverIndex = 1;
    private bool leverState = false;
    private static bool firstLeverOpened = false;
    private static bool secondLeverClosed = true;
    private static bool thirdLeverOpened = false;
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleLever();
        }
    }
    private void ToggleLever()
    {
        leverState = !leverState;
        leverAnimator.SetBool("LeverToggle", leverState);
        switch (leverIndex)
        {
            case 1:
                firstLeverOpened = leverState;
                break;
            case 2:
                secondLeverClosed = !leverState;
                break;
            case 3:
                thirdLeverOpened = leverState;
                break;
        }
        CheckLeverSequence();
    }
    private void CheckLeverSequence()
    {
        if (firstLeverOpened && secondLeverClosed && thirdLeverOpened)
        {
            trapDoorAnimator.SetTrigger("open");
        }
        else
        {
            trapDoorAnimator.SetTrigger("close");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
