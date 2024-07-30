using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour
{
    [SerializeField] private Animator spikeTrapAnim = null; // Reference to the Animator component
    private Coroutine trapCoroutine; // Reference to the coroutine

    void Awake()
    {
        // Automatically assign the Animator component if it's not manually assigned
        if (spikeTrapAnim == null)
        {
            spikeTrapAnim = GetComponent<Animator>();
        }
    }

    void OnEnable()
    {
        Debug.Log(gameObject.name + " enabled");
        StartTrap();
    }

    void OnDisable()
    {
        Debug.Log(gameObject.name + " disabled");
        StopTrap();
    }

    public void StartTrap()
    {
        if (trapCoroutine == null)
        {
            trapCoroutine = StartCoroutine(OpenCloseTrap());
        }
    }

    public void StopTrap()
    {
        if (trapCoroutine != null)
        {
            StopCoroutine(trapCoroutine);
            trapCoroutine = null;
            spikeTrapAnim.SetTrigger("close");
        }
    }

    private IEnumerator OpenCloseTrap()
    {
        while (true)
        {
            // Play the open animation
            spikeTrapAnim.SetTrigger("open");
            // Wait for 2 seconds
            yield return new WaitForSeconds(2);
            // Play the close animation
            spikeTrapAnim.SetTrigger("close");
            // Wait for 2 seconds
            yield return new WaitForSeconds(2);
        }
    }
}
