using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    public Transform target; // Reference to the player
    public float distance = 5f; // Default distance from the player
    public float height = 2f; // Default height of the camera
    public float minHeight = 1f; // Minimum height of the camera
    public float maxHeight = 10f; // Maximum height of the camera
    public float heightDamping = 5f; // Speed of height adjustment
    public float rotationSpeed = 1f; // Speed of rotation adjustment
    public float damping = 5f; // Speed of position smoothing
    public float collisionOffset = 0.5f; // Offset to avoid clipping into walls
    public LayerMask collisionMask; // Layers considered as obstacles

    private float currentRotationAngle;
    private float currentHeight;
    private float targetHeight;

    void Start()
    {
        // Initialize heights
        currentHeight = height;
        targetHeight = height;
    }

    void Update()
    {
        if (!target) return;

        // Adjust rotation based on mouse input
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        currentRotationAngle += horizontalInput;

        // Adjust height based on scroll input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        targetHeight -= scrollInput * 10f;
        targetHeight = Mathf.Clamp(targetHeight, minHeight, maxHeight);
        currentHeight = Mathf.Lerp(currentHeight, targetHeight, heightDamping * Time.deltaTime);

        // Calculate desired position
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        Vector3 desiredPosition = target.position - currentRotation * Vector3.forward * distance;
        desiredPosition.y = target.position.y + currentHeight;

        // Check for collisions
        RaycastHit hit;
        if (Physics.Linecast(target.position, desiredPosition, out hit, collisionMask))
        {
            // Adjust the desired position to the hit point
            desiredPosition = hit.point + hit.normal * collisionOffset;
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, target.position.y + minHeight, target.position.y + maxHeight);
        }

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

        // Look at the target
        transform.LookAt(target.position + Vector3.up * height);
    }
}
