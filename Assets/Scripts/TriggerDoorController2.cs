using UnityEngine;
class TriggerDoorController2 : MonoBehaviour
{
    [SerializeField] private Animator doorLeft = null;
    [SerializeField] private Animator doorRight = null;
    [SerializeField] private bool isDoubleDoor = false;
    [SerializeField] private bool requiresKey2 = false;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyCollector keyCollector = other.GetComponent<KeyCollector>();
            if (keyCollector != null)
            {
                if (requiresKey2 && keyCollector.hasKey2)
                {
                    HandleDoorOperation(doorLeft, openTrigger, closeTrigger);
                    if (isDoubleDoor)
                    {
                        HandleDoorOperation(doorRight, openTrigger, closeTrigger);
                    }
                    gameObject.SetActive(false);
                }
                else if (!requiresKey2 && keyCollector.hasKey)
                {
                    HandleDoorOperation(doorLeft, openTrigger, closeTrigger);
                    if (isDoubleDoor)
                    {
                        HandleDoorOperation(doorRight, openTrigger, closeTrigger);
                    }
                    gameObject.SetActive(false);
                }
            }
        }
    }
    private void HandleDoorOperation(Animator door, bool open, bool close)
    {
        if (door != null)
        {
            door.SetBool("isKeyCollected", true);
            if (open)
            {
                door.SetBool("Open", true);
                door.SetBool("Close", false);
            }
            else if (close)
            {
                door.SetBool("Open", false);
                door.SetBool("Close", true);
            }
        }
    }
}
