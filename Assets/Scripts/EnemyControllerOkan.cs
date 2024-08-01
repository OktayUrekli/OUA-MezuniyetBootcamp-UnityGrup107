using System.Collections;
using UnityEngine;

public class EnemyControllerOkan : MonoBehaviour
{
    public float health = 100f; // Enemy's health
    public float speed = 2f; // Enemy's movement speed
    public float attackDamage = 10f; // Damage dealt to the player
    public float attackRange = 2f; // Range within which the enemy can attack the player
    public float attackCooldown = 1f; // Time between attacks

    public Transform player; // Reference to the player
    private PlayerController1 playerController; // Reference to the PlayerController script
    private bool isAttacking = false; // Is the enemy currently attacking

    private Animator animator;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerController = playerObject.GetComponent<PlayerController1>();
        }
        else
        {
            Debug.LogError("Player GameObject with tag 'Player' not found.");
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the enemy GameObject.");
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
            return;
        }

        if (player != null)
        {
            MoveTowardsPlayer();

            if (playerController != null && !playerController.IsDead && Vector3.Distance(transform.position, player.position) <= attackRange && !isAttacking)
            {
                StartCoroutine(AttackPlayer());
            }
        }
        else
        {
            Debug.LogWarning("Player reference is missing. Make sure the Player GameObject is assigned.");
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null && !playerController.IsDead && !isAttacking)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(player);
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;

        // Play attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        if (playerController != null && !playerController.IsDead)
        {
            playerController.TakeDamage(attackDamage);
        }

        // Wait for the attack cooldown before allowing another attack
        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        // Play damage animation if available
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play death animation
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Disable the enemy (or destroy it after a delay to let the animation play)
        Destroy(gameObject, 2f);
    }
}
