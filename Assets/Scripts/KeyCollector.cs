using UnityEngine;
public class KeyCollector : MonoBehaviour
{
    public bool hasKey = false;
    public bool hasKey2 = false;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
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
        else if (other.gameObject.CompareTag("Key2"))
        {
            hasKey2 = true;
            Destroy(other.gameObject);
            if (animator != null)
            {
                animator.SetBool("isKeyCollected", true);
            }
        }
    }
    public void ResetKeyState()
    {
        hasKey = false;
        hasKey2 = false;
        if (animator != null)
        {
            animator.SetBool("isKeyCollected", false);
        }
    }
}
