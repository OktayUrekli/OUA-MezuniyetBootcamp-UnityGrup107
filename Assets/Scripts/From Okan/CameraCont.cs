using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraCont : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float minHeight = 1f;
    public float maxHeight = 10f;
    public float heightDamping = 5f;
    public float rotationSpeed = 1f;
    public float damping = 5f;
    private float currentRotationAngle;
    private float currentHeight;
    private float targetHeight;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        currentHeight = height;
        targetHeight = height;
    }
    void Update()
    {
        if (!target) return;
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        currentRotationAngle += horizontalInput;
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        targetHeight -= scrollInput * 10f;
        targetHeight = Mathf.Clamp(targetHeight, minHeight, maxHeight);
        currentHeight = Mathf.Lerp(currentHeight, targetHeight, heightDamping * Time.deltaTime);
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        Vector3 desiredPosition = target.position - currentRotation * Vector3.forward * distance;
        desiredPosition.y = target.position.y + currentHeight;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.LookAt(target.position + Vector3.up * height);
    }
}
