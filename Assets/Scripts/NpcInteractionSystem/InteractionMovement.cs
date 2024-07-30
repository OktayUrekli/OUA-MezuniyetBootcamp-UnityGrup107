using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractionMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
