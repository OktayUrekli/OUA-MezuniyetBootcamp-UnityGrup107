using System.Collections;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] private float playerHealth = 100f;
    public float MaxPlayerHealth { get; private set; } = 100f;

    public float PlayerHealth
    {
        get { return playerHealth; }
        set
        {
            playerHealth = Mathf.Clamp(value, 0, MaxPlayerHealth);
            if (playerHealth <= 0 && !IsDead)
            {
                Death();
            }
            UpdateUI(); // Call to update health UI
        }
    }

    public float walkSpeed = 2f;
    public float runSpeed = 6f;
    public float crouchSpeed = 1f;
    public float jumpForce = 10f;
    public float forwardJumpOffset = 1f;
    public Transform orientation;

    private Rigidbody rb;
    private bool isCrouching = false;
    private bool isGrounded = true;
    private bool isAttacking = false;
    private Animator regularAnimator;
    private Animator combatAnimator;
    private Animator currentAnimator;

    public GameObject regularModel;
    public GameObject combatModel;
    private bool isInvulnerable = false;
    public float invulnerabilityDuration = 1f;
    public float rotationSpeed = 180f;

    public bool IsDead { get; private set; } = false;

    private bool canAttack = true;
    public float attackCooldown = 0.5f;

    public SwordAttack swordAttack; // Assign this in the inspector or find it in code

    private void Start()
    {
        MaxPlayerHealth = playerHealth; // Set max health at the start

        rb = GetComponent<Rigidbody>();
        regularAnimator = regularModel.GetComponent<Animator>();
        combatAnimator = combatModel.GetComponent<Animator>();
        regularModel.SetActive(true);
        combatModel.SetActive(false);
        currentAnimator = regularAnimator;

        UpdateUI(); // Initialize health UI
    }

    void Update()
    {
        if (IsDead) return; // Skip player actions if dead

        Move();
        RotatePlayer();
        Crouch();

        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouching)
        {
            currentAnimator.SetTrigger("Jump");
            ApplyJumpForce();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleCombatMode();
        }

        if (combatModel.activeSelf && !isAttacking && Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    void Move()
    {
        if (IsDead) return; // Skip movement if dead

        float move = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isWalking = move != 0 || strafe != 0;

        float speed = isCrouching ? crouchSpeed : (isRunning ? runSpeed : walkSpeed);

        Vector3 forward = orientation.forward;
        Vector3 right = orientation.right;
        Vector3 movement = (forward * move + right * strafe) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        currentAnimator.SetBool("isWalking", isWalking);
        currentAnimator.SetBool("isRunning", isRunning && !isCrouching);
    }

    void RotatePlayer()
    {
        if (IsDead) return; // Skip rotation if dead

        float rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.deltaTime);
    }

    void Crouch()
    {
        if (IsDead) return; // Skip crouching if dead

        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
            currentAnimator.SetBool("isCrouching", isCrouching);
        }
    }

    void ApplyJumpForce()
    {
        if (IsDead) return; // Skip jumping if dead

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            currentAnimator.SetBool("isGrounded", isGrounded);
        }
    }

    public void TakeDamage(float damage)
    {
        if (isInvulnerable) return;

        PlayerHealth -= damage; // Update player health
    }

    public void Heal(float healAmount)
    {
        PlayerHealth += healAmount; // Heal player
    }

    private void Death()
    {
        IsDead = true;
        currentAnimator.SetTrigger("Dying");

        // Disable movement and physics
        rb.isKinematic = true; // Prevent the Rigidbody from moving
        rb.velocity = Vector3.zero; // Stop any current movement

        // Optionally, you could disable player controls here
        // e.g., this.enabled = false; // Disable the PlayerController script

        Debug.Log("You died!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            currentAnimator.SetBool("isGrounded", isGrounded);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You got hit.");

            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                TakeDamage(enemy.attackDamage);
                if (!isInvulnerable)
                {
                    StartCoroutine(InvulnerabilityCoroutine());
                }
            }
        }
    }

    private void UpdateUI()
    {
        PlayerUIOkan playerUI = UnityEngine.Object.FindFirstObjectByType<PlayerUIOkan>();
        if (playerUI != null)
        {
            playerUI.UpdateHealthUI(); // Update the UI without parameters
        }
    }

    void ToggleCombatMode()
    {
        if (IsDead) return; // Skip combat mode toggle if dead

        bool isCombatMode = combatModel.activeSelf;
        combatModel.SetActive(!isCombatMode);
        regularModel.SetActive(isCombatMode);
        currentAnimator = isCombatMode ? regularAnimator : combatAnimator;
    }

    IEnumerator Attack()
    {
        if (isAttacking || !canAttack) yield break;

        isAttacking = true;

        // Trigger a single attack animation
        currentAnimator.SetTrigger("Attack1");

        // Wait for the length of the attack animation
        yield return new WaitForSeconds(currentAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Set sword damage (example: 20)
        if (swordAttack != null)
        {
            swordAttack.damage = 20f; // Adjust this value as needed
        }

        canAttack = false;

        // Cooldown period before next attack is allowed
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
        isAttacking = false;
    }

    IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true;

        yield return new WaitForSeconds(invulnerabilityDuration);

        // Revert to normal state
        isInvulnerable = false;
    }
}
