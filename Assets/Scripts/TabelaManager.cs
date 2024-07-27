using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabelaManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tabelaText;

    private void Start()
    {
         tabelaText.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tabelaText.enabled = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tabelaText.enabled = false;
        }
    }
}
