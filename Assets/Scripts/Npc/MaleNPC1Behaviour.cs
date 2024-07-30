using UnityEngine;
using UnityEngine.AI;
public class MaleNPC1Behaviour : MonoBehaviour
{
    Animator npcAnimator;
    NavMeshAgent agent;
    public int randIdleTime,randTalkingTime;
    public Vector3 targetDestination;
    public float npcSpeed;
    public bool atTalkinPoint;
    bool talking;
    public Transform npc;
    [SerializeField]GameObject[] talkableNPC;
    private void Awake()
    {
        talkableNPC = GameObject.FindGameObjectsWithTag("NPC2");
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        npcAnimator = GetComponent<Animator>();
        atTalkinPoint=true;
        SetIdleTime();
    }
    void Update()
    {
        if (atTalkinPoint == false)
        {
            NpcPositionControl();
        }
    }
    void SetIdleTime()
    {
        npcSpeed = 0f;
        npcAnimator.SetFloat("Speed", npcSpeed);
        talking = false;
        npcAnimator.SetBool("Talking", talking);
        randIdleTime = Random.Range(2, 5);
        Invoke("FindTalkPoint", randIdleTime);
    }
    void SetTalkingTime()
    {
        randTalkingTime = Random.Range(5, 15);
        transform.LookAt(npc);
        talking = true;
        npcAnimator.SetBool("Talking", talking);
        npcSpeed = 0f;
        npcAnimator.SetFloat("Speed", npcSpeed);
        Invoke("SetIdleTime", randTalkingTime);
    }
    void FindTalkPoint()
    {
        npcSpeed = 1f;
        npcAnimator.SetFloat("Speed", npcSpeed);
        atTalkinPoint = false;
        npc = talkableNPC[Random.Range(0, talkableNPC.Length)].transform;
        targetDestination = npc.GetChild(Random.Range(0,3)).transform.position;
        agent.destination = new Vector3(targetDestination.x,transform.position.y,targetDestination.z);
    }
    void NpcPositionControl()
    {
        if (Vector3.Distance(transform.position , targetDestination)<1f )
        {
            atTalkinPoint = true;
            npcSpeed = 0f;
            npcAnimator.SetFloat("Speed", npcSpeed);
            SetTalkingTime();
        }
    }
}
