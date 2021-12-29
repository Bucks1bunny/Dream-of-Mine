using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public Transform player;
    public LayerMask Ground, Player;
    
    //   Patroling
    private Vector3 walkPoint;
    bool walkPointSet;
    private float walkPointRange = 10f;

    //   Attacking
    public float damage = 10f;
    public float timeBetweenAttacks = 3f;
    bool alreadyAttacked;
    
    //   States
    public float sightRange;
    public float attackRange;
    private bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) Chasing();
        if (playerInAttackRange) Attacking();

    }
    private void Patroling()
    {
        if (!walkPointSet) WalkToRandomPoint();
        if (walkPointSet)  navMesh.SetDestination(walkPoint);

        Vector3 walkToPoint = transform.position - walkPoint;

        if (walkToPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void WalkToRandomPoint()
    {
        // Get random points
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        //Walk towards points
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f,Ground))
            walkPointSet = true;
    }
    private void Chasing()
    {
        navMesh.SetDestination(player.position);
    }
    private void Attacking()
    {
        navMesh.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            PlayerHealthSystem target = player.GetComponent<PlayerHealthSystem>();
            if(target != null)
                target.TakeDamage(damage);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
