using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] private float playerHealth = 100f;
    public float walkSpeed = 2f;
    public float runSpeed = 6f;
    public float crouchSpeed = 1f;
    public float jumpForce = 10f; 
    public float forwardJumpOffset = 1f; 
    public Transform orientation; // Reference to the Orientation object

    private Rigidbody rb;
    private Animator animator;

    private bool isCrouching = false;
    private bool isGrounded = true;
    public bool isDead = false;

    private bool rotateCharacter = false;
    private float rotationSpeed = 180f;

    public bool IsDead
    {
        get { return isDead; }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            Move();
            RotatePlayer();
            Crouch();

            if (Input.GetButtonDown("Jump") && isGrounded && !isCrouching)
            {
                animator.SetTrigger("Jump");
            }

            UpdateAnimator();

            if (Input.GetMouseButtonDown(1))
            {
                rotateCharacter = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                rotateCharacter = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDead && rotateCharacter)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(Vector3.up, mouseX);
        }
    }

    void Move()
    {
        float move = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isWalking = move != 0 || strafe != 0;

        float speed = isCrouching ? crouchSpeed : (isRunning ? runSpeed : walkSpeed);

        // Get forward and right vectors based on orientation
        Vector3 forward = orientation.forward;
        Vector3 right = orientation.right;

        // Project movement onto the oriented axes
        Vector3 movement = (forward * move + right * strafe) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // Update animator parameters
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning && !isCrouching);
    }

    void RotatePlayer()
    {
        // Rotate the player based on horizontal input (A and D keys)
        float rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.deltaTime);
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
            animator.SetBool("isCrouching", isCrouching);
        }
    }

    void UpdateAnimator()
    {
        animator.SetBool("isGrounded", isGrounded);
    }

    public void ApplyJumpForce()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            UpdateAnimator();
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        Debug.Log("Player health: " + playerHealth);

        if (playerHealth <= 0 && !isDead)
        {
            Death();
        }

        UpdateUI();
    }

    void Death()
    {
        isDead = true;
        animator.SetTrigger("Dying");
        Debug.Log("You died!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            UpdateAnimator();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You got hit.");

            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                TakeDamage(enemy.attackDamage);
            }
        }
    }

    void UpdateUI()
    {
        PlayerUI playerUI = FindObjectOfType<PlayerUI>();
        if (playerUI != null)
        {
            playerUI.UpdateHealthUI(playerHealth);
        }
    }
}