using UnityEngine;
using UnityEngine.AI;

public class Enemy1Behaviour : MonoBehaviour
{
    Animator enemyAnimator;
    NavMeshAgent agent;

    [SerializeField] float range;
    public bool inFollowRange;
    public bool inAttackRange;
    [SerializeField]  Vector3 newDestination;
    public bool atNewDestination;
    [SerializeField] LayerMask groundLayer;

    float time;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        SetIdleDuration();   
    }

    
    void Update()
    {
        if (!atNewDestination)
        {
           PositionControl();
        }

    }

    void SetIdleDuration()
    {
        int idleDuration=Random.Range(2,5);
        enemyAnimator.SetFloat("Speed", 0);
        Invoke("SetRandomDestination", idleDuration);
    }

    void SetRandomDestination()
    {
        atNewDestination = false;
        float x = Random.Range(-range,range);
        float z = Random.Range(-range, range);
        newDestination=new Vector3(transform.position.x+x,transform.position.y,transform.position.z+z);
        enemyAnimator.SetFloat("Speed", 1);
        agent.SetDestination(newDestination);
        time = 0;
        Timer();

    }

    void Timer()
    {   
        time += 1;
        Invoke("Timer", 1);
    }

    

    void PositionControl()
    {
        if (Vector3.Distance(transform.position,newDestination)<1 || (time >= 20 && !inFollowRange))
        {
            atNewDestination = true;
            SetIdleDuration();
        }
        else
        {
            atNewDestination = false;
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inAttackRange = true;
            enemyAnimator.SetFloat("Speed", 0);
            enemyAnimator.SetBool("Attack", inAttackRange);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inAttackRange = false;
            enemyAnimator.SetFloat("Speed", 1);
            enemyAnimator.SetBool("Attack", inAttackRange);
            newDestination = collision.transform.position;
            agent.SetDestination(newDestination) ;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inFollowRange = true;
            newDestination = other.transform.position;
            agent.SetDestination(newDestination);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inFollowRange = false; 
            newDestination=transform.position;
            enemyAnimator.SetFloat("Speed", 0);
            SetIdleDuration();
        }
    }

     /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 3);
    }
     */
}
