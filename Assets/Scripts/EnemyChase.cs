using UnityEngine;
using UnityEngine.AI; // Required for NavMeshAgent

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    public Transform player;       // Reference to the player's position
    private NavMeshAgent agent;    // Reference to the NavMeshAgent component

    [Header("Stats")]
    public float chaseRange = 10f; // How far the enemy can "see"
    public float attackRange = 2f; // How close the enemy gets before stopping

    void Start()
    {
        // 1. Get the NavMeshAgent attached to this object
        agent = GetComponent<NavMeshAgent>();

        // 2. Automatically find the player if not assigned manually
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        // 3. Calculate distance between Enemy and Player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 4. Logic: Decide what to do based on distance
        if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange)
        {
            ChasePlayer();
        }
        else if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
        else
        {
            StopChasing();
        }
    }

    void ChasePlayer()
    {
        // Tell the NavMeshAgent to move to the player's position
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        // Stop moving so we can attack
        agent.isStopped = true;
        // (Add attack logic or animation code here later)
        Debug.Log("Attacking!"); 
    }

    void StopChasing()
    {
        // Stop moving if player is too far away
        agent.isStopped = true;
    }
    
    // Visualize the ranges in the Scene view for easy debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}