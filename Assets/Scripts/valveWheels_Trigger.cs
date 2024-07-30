using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class valveWheels_Trigger : MonoBehaviour
{
    [SerializeField] private Animator valveWheels = null;
    private bool playerInRange = false;
    public bool valveWheelsState = false;
    [SerializeField] private GameObject spikeTrap1;
    private void Start()
    {
        valveWheels.SetBool("valveWheelsState", valveWheelsState);
        SetInitialSpikeTrapState();
    }
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
            ToggleSpikeTraps();
        }
    }
    public void Interaction()
    {
        valveWheelsState = !valveWheelsState;
        valveWheels.SetBool("valveWheelsState", valveWheelsState);
    }
    void ToggleSpikeTraps()
    {
        foreach (Transform spikeTrap in spikeTrap1.transform)
        {
            SpikeTrapDemo spikeTrapDemo = spikeTrap.GetComponent<SpikeTrapDemo>();
            if (spikeTrapDemo != null)
            {
                if (valveWheelsState)
                {
                    spikeTrapDemo.enabled = true;
                }
                else
                {
                    spikeTrapDemo.StopTrap();
                    spikeTrapDemo.enabled = false;
                }
            }
        }
    }
    void SetInitialSpikeTrapState()
    {
        foreach (Transform spikeTrap in spikeTrap1.transform)
        {
            SpikeTrapDemo spikeTrapDemo = spikeTrap.GetComponent<SpikeTrapDemo>();
            if (spikeTrapDemo != null)
            {
                spikeTrapDemo.enabled = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
