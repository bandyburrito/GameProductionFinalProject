using UnityEngine;
using UnityEngine.AI; // Needed for NavMeshAgent

// This line guarantees the enemy has the agent, so you don't crash!
[RequireComponent(typeof(NavMeshAgent))]
public class SimpleChaser : MonoBehaviour
{
    public Transform player;      // Drag your Player object here in the Inspector
    public float chaseDistance = 10f; // How close the player needs to be to start the chase
    
    private NavMeshAgent agent;
    private float distanceToPlayer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Safety check: make sure we actually assigned a player
        if (player == null) return;

        // 1. Calculate distance
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 2. If close enough, chase!
        if (distanceToPlayer <= chaseDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            // Optional: Stop moving if the player gets too far away
            agent.isStopped = true;
        }
    }
}