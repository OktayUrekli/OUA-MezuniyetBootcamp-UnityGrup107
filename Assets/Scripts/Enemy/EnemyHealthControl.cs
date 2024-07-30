using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthControl : MonoBehaviour
{
    Animator enemyAnimator;
    [SerializeField] int health;
    [SerializeField] Image healthBar;
    int maxHealth;
    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        maxHealth = health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 25;
            enemyAnimator.SetTrigger("Hurt");
            IsDead();
        }
    }
    void IsDead()
    {
        if (health <= 0)
        {
            gameObject.GetComponent<Enemy1Behaviour>().enabled = false;
            enemyAnimator.SetBool("Dead",true);
            enemyAnimator.SetFloat("Speed", 0);
            healthBar.fillAmount = (float)health / maxHealth;
        }
        else
        {
            healthBar.fillAmount = (float)health / maxHealth;
        }
    }
}
