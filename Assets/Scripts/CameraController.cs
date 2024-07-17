using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target to follow (your player's transform)
    public float distance = 5f; // Distance from the target
    public float height = 2f; // Height above the target
    public float minHeight = 1f; // Minimum height above the target
    public float maxHeight = 10f; // Maximum height above the target
    public float heightDamping = 5f; // Smoothness of height adjustment
    public float rotationSpeed = 1f; // Speed of camera rotation
    public float damping = 5f; // Smoothness of camera movement

    private float currentRotationAngle;
    private float currentHeight;
    private float targetHeight;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        Cursor.visible = false; // Hide cursor
        currentHeight = height;
        targetHeight = height;
    }

    void Update()
    {
        if (!target)
            return;

        if (Input.GetMouseButton(1)) 
        {
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
            currentRotationAngle += horizontalInput;
        }

        // Adjust height based on mouse scroll wheel or up/down keys
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        targetHeight -= scrollInput * 10f;
        targetHeight = Mathf.Clamp(targetHeight, minHeight, maxHeight); // Limit height range

        // Smoothly adjust current height towards the target height
        currentHeight = Mathf.Lerp(currentHeight, targetHeight, heightDamping * Time.deltaTime);

        // Calculate desired position and rotation of the camera
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        Vector3 desiredPosition = target.position - currentRotation * Vector3.forward * distance;
        desiredPosition.y = target.position.y + currentHeight;

        // Smoothly move and rotate the camera towards the desired position and rotation
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.LookAt(target.position + Vector3.up * height);
    }
}