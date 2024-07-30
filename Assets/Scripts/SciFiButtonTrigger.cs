using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SciFiButtonTrigger : MonoBehaviour
{
    private bool playerInRange = false;
    [SerializeField] private Animator buttonAnimator = null;
    [SerializeField] private GameObject object1 = null;
    [SerializeField] private GameObject object2 = null;
    [SerializeField] private int buttonIndex = 1;
    private bool buttonState = false;
    private static bool firstButtonPressed = false;
    private static bool secondButtonPressed = false;
    private static bool thirdButtonPressed = false;
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleButton();
        }
    }
    private void ToggleButton()
    {
        buttonState = !buttonState;
        buttonAnimator.SetBool("isPressed", buttonState);
        switch (buttonIndex)
        {
            case 1:
                firstButtonPressed = buttonState;
                break;
            case 2:
                secondButtonPressed = buttonState;
                break;
            case 3:
                thirdButtonPressed = buttonState;
                break;
        }
        CheckButtonSequence();
    }
    private void CheckButtonSequence()
    {
        if (firstButtonPressed && secondButtonPressed && thirdButtonPressed)
        {
            ToggleObjects(true);
        }
        else
        {
            ToggleObjects(false);
        }
    }
    private void ToggleObjects(bool state)
    {
        if (object1 != null)
        {
            object1.SetActive(state);
        }
        if (object2 != null)
        {
            object2.SetActive(state);
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
