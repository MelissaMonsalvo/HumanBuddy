using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using UnityEngine.Events;



public class Enemy : MonoBehaviour
{

    public Transform[] waypoints;
    public Vector2 waitTime;

    public UnityEvent OnIdle;
    public UnityEvent OnChase;
    public UnityEvent OnPatrol;
    public UnityEvent OnAttack;
    public UnityEvent OnDamage;
    public UnityEvent OnDeath;

    private NavMeshAgent agent;
    private Animator animator;
    private Vector3 destination;
    private int index=0;
    private bool waiting;
    public EnemyState currentState;
    private RaycastHit hitSphereCast;
    private Transform playerTransform;
    public PlayerProfile playerProfile;

    /*public float distanceSphereCast;
    public float radiusSphereCast;
    public LayerMask layersSphereCast;
    public Transform originSphereCast;
    */
   // public GameEvent ChaseGameEvent;
    //public GameEvent PatrolGameEvent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        index = 0;
        waiting = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        ChangeState(EnemyState.IDLE);
       
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerTransform.position - transform.position).magnitude < 5f)
        {
            if (currentState == EnemyState.IDLE || currentState == EnemyState.PATROL)
            {
                ChangeState(EnemyState.CHASE);
            }
        }
        else
        {
            if (currentState == EnemyState.ATTACK)
            {
                ChangeState(EnemyState.IDLE);
            }
        }

        if (currentState == EnemyState.CHASE)
            ExecuteChase();

        if (agent.remainingDistance < 0.00001f && currentState == EnemyState.PATROL)
        {
            ChangeState(EnemyState.IDLE);
        }
        if (agent.remainingDistance < 1.2f && currentState == EnemyState.CHASE)
        {
            ChangeState(EnemyState.ATTACK);
            Debug.Log("Cerca");
        }
    }

    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case EnemyState.IDLE:
                SetStateToIdle();
                break;
            case EnemyState.PATROL:
                SetStateToPatrol();
                break;
            case EnemyState.CHASE:
                SetStateToChase();
                break;
            case EnemyState.DAMAGE:
                SetStateToDamage();
                break;
            case EnemyState.DEATH:
                SetStateToDeath();
                break;
            case EnemyState.ATTACK:
                SetStateToAttack();
                break;
        }
    }

    private void SetStateToIdle()
    {
        StartCoroutine("ExecuteIdle");
        OnIdle.Invoke();
    }
    private void SetStateToPatrol()
    {
        ExecutePatrol();
        //PatrolGameEvent.Raise();
        OnPatrol.Invoke();
    }
    private void SetStateToChase()
    {
        ExecuteChase();
        //ChaseGameEvent.Raise();
        OnChase.Invoke();
    }
    private void SetStateToDamage()
    {
        ExecuteDamage();
        OnDamage.Invoke();
    }
    private void SetStateToDeath()
    {
        ExecuteDeath();
        OnDeath.Invoke();
    }
    private void SetStateToAttack()
    {
        ExecuteAttack();
        OnAttack.Invoke();
    }

    private IEnumerator SetObjective()
    {
        
        destination = waypoints[index].position;
        waiting = true;
        yield return new WaitForSeconds(Random.Range(waitTime.x, waitTime.y));
        agent.SetDestination(destination);
        waiting = false;
        index++;
        if (index >= waypoints.Length)
            index = 0;


    }
    IEnumerator ExecuteIdle()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(Random.Range(waitTime.x, waitTime.y));
        ChangeState(EnemyState.PATROL);
    }

    private void ExecutePatrol()
    {
        agent.isStopped = false;
        StopCoroutine("ExecuteIdle");
        destination = waypoints[index].position;
        agent.SetDestination(destination);
        index++;
        if (index >= waypoints.Length)
            index = 0;
    }
    private void ExecuteChase()
    {
        agent.isStopped = false;
        StopCoroutine("ExecuteIdle");
        agent.SetDestination(playerTransform.position);
    }
    public void ExecuteAttack()
    {
        agent.isStopped = true;
        animator.SetTrigger("attack");
        playerProfile.ReduceLiveLevel();
        //ValidateAttack();
        Debug.Log("Ataca");
        //animator.SetTrigger("attack");
    }

    IEnumerator ExecuteAttack2()
    {
        agent.isStopped = true;
        playerProfile.ReduceLiveLevel();
        Debug.Log("Ataca");
        yield return new WaitForSeconds(5);
        //animator.SetTrigger("attack");
    }

    private void ExecuteDamage()
    {
        //animator.SetTrigger("damage");
    }
    private void ExecuteDeath()
    {
        //animator.SetTrigger("muerto");
    }
    public void ValidateAttack()
    {
        Debug.Log("Valida");
        if ((playerTransform.position - transform.position).magnitude > 2f)
        {
            if (currentState == EnemyState.ATTACK)
                ChangeState(EnemyState.IDLE);
        }
        else
        {
            if (currentState == EnemyState.ATTACK)
                ChangeState(EnemyState.CHASE);
        }
    }


}
public enum EnemyState
{
    IDLE,
    PATROL,
    CHASE,
    ATTACK,
    DAMAGE,
    DEATH
}
