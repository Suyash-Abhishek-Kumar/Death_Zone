using UnityEngine;

[RequireComponent(typeof(ZombieStats))]
public class ZombieAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;

    private float lastAttackTime;
    private Transform player;
    private ZombieStats stats;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stats = GetComponent<ZombieStats>();
    }

    private void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    private void Attack()
    {
        // PlayerHealth should exist on player object
        PlayerHealth ph = player.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage(stats.GetDamage());
        }

        Debug.Log(gameObject.name + " attacked player!");
    }
}
