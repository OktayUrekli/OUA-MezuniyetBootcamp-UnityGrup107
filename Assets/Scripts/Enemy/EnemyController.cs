using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2f;
    public float attackDamage = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private Transform player;
    private PlayerController1 playerController;
    private bool isAttacking = false;
    private Animator animator;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerController = playerObject.GetComponent<PlayerController1>();
        }
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (health <= 0)
        {
            Die();
            return;
        }
        MoveTowardsPlayer();
        if (playerController != null && !playerController.IsDead && Vector3.Distance(transform.position, player.position) <= attackRange && !isAttacking)
        {
            StartCoroutine(AttackPlayer());
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
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
        if (playerController != null && !playerController.IsDead)
        {
            playerController.TakeDamage(attackDamage);
        }
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
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
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
        Destroy(gameObject, 2f);
    }
}
