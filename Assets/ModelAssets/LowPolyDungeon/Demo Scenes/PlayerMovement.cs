using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;

    public float interactionDistance = 3f;
    public float pushForce = 10f;
    public float pullForce = 10f;
    public Vector3 startPosition;
    public Camera mainCamera;
    public bool hasKey = false;

    private Animator animator;
    private GameObject interactableObject;
    private Vector3 velocity;
    private float speedBoost = 1f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();

        Application.targetFrameRate = 60;

        ResetPlayerState();
    }

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButton("Fire3"))
            speedBoost = sprintSpeed;
        else
            speedBoost = 1f;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }

        if (Input.GetKey(KeyCode.W) && interactableObject != null)
        {
            PushObject();
        }

        if (Input.GetKey(KeyCode.S) && interactableObject != null)
        {
            PullObject();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            ReleaseObject();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
            if (animator != null)
            {
                animator.SetBool("isKeyCollected", true);
            }
        }
    }

    public void ResetToStartPosition()
    {
        transform.position = startPosition;
        velocity = Vector3.zero;

        if (mainCamera != null)
        {

        }

        ResetPlayerState();
    }

    void ResetPlayerState()
    {
        hasKey = false;
        velocity = Vector3.zero;
        speedBoost = 1f;
        interactableObject = null;

        if (animator != null)
        {
            animator.SetBool("isKeyCollected", false);
        }
    }

    void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                interactableObject = hit.collider.gameObject;
            }
        }
    }

    void PushObject()
    {
        if (interactableObject != null)
        {
            Rigidbody rb = interactableObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Camera.main.transform.forward * pushForce);
            }
        }
    }

    void PullObject()
    {
        if (interactableObject != null)
        {
            Rigidbody rb = interactableObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(-Camera.main.transform.forward * pullForce);
            }
        }
    }

    void ReleaseObject()
    {
        interactableObject = null;
    }
}
