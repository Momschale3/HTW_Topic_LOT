using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [Header("Enemy Property Floats")]

    public float lookRadius = 10f;
    public float SpeedStop = 0f;
    public float SpeedNormal = 13f;

    public float AttackRange;

    [Space(10)]

    private float Timer;
    public float TimeNow;
    public float AttackCooldown;

    [Header("Assignements")]
    Transform target;
    NavMeshAgent agent;
    public GameManagerScript GMS;


    [Header("GameObjects")]
    public GameObject StartPoint;

    [Header("Bools")]
    public bool EnemyAttacks = false;

    public bool playerInAttackRange;

    [Header("LayerMasks")]

    public LayerMask Player;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Third Person Player").transform;
        agent = GetComponent<NavMeshAgent>();

   
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);

        /*/--------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

        if (distance <= lookRadius && EnemyAttacks == false)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // Attack the target
                FaceTarget();
            }
        }
        /*/--------------------------------------------------------------------------------------------------------------------------------------------------------------/*/
        if (distance >= lookRadius && EnemyAttacks == false)
        {
            Vector3 PathToStartPoint = (StartPoint.transform.position);
            agent.SetDestination(PathToStartPoint);

        }
        /*/--------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

        if (distance <= 1.0f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        /*/--------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

        playerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, Player);

        if(playerInAttackRange == true)
        {
            TimeNow = Time.time;

            if (TimeNow > Timer)
            {

                Timer = Time.time + AttackCooldown;

                GMS.TakeDamage();
            }
        }

        /*/--------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public float LookRadiusDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        return distance;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
