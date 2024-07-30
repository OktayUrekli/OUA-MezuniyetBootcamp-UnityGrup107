using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("NPC2"))
        {
            InteractionPanel.instance.OpenPanel();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("NPC2"))
        {
            InteractionPanel.instance.ClosePanel();
        }
    }
}
