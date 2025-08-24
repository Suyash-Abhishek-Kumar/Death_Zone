using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ZombieStats))]
public class ZombieMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private ZombieStats stats;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<ZombieStats>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = stats.GetSpeed();
    }

    private void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}
