using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [Header("Zombie Spawning")]
    public GameObject zombiePrefab;
    public int zombieCount = 5;
    public float spawnRadius = 15f;
    public Transform player;

    private void Start()
    {
        SpawnZombies();
    }

    private void SpawnZombies()
    {
        for (int i = 0; i < zombieCount; i++)
        {
            Vector3 spawnPos = player.position + Random.insideUnitSphere * spawnRadius;
            spawnPos.y = 0; // Keep it on ground

            // Prevent spawning on top of the player
            if (Vector3.Distance(spawnPos, player.position) > 3f)
            {
                Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
            }
        }
    }
}
