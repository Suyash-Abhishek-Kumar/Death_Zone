using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    /*[Header("Zombie Spawning")]
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
    }*/
    [System.Serializable]
    public class EnemyType
    {
        public GameObject prefab;  // enemy prefab
        public int weight = 1;     // higher = more chance to spawn
    }

    public Transform player;
    public EnemyType[] enemyTypes; // assign in inspector
    public Transform[] spawnPoints; // set spawn points in inspector
    public float spawnInterval = 3f;
    public int maxEnemies;
    public int spawnRadius = 20;

    private int currentEnemies = 0;
    private int totalcurrent = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies || enemyTypes.Length == 0 || spawnPoints.Length == 0)
            return;

        // pick spawn point
        Vector3 spawnPoint = player.position + Random.insideUnitSphere * spawnRadius;
        spawnPoint.y = 2;

        // pick enemy type (weighted random)
        GameObject enemyPrefab = ChooseEnemyType();

        if (enemyPrefab != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            currentEnemies++;
            totalcurrent++;

            // auto decrease when enemy dies (requires your enemy to call OnDestroy or custom event)
            enemy.AddComponent<EnemyTracker>().Init(this);
        }
    }

    GameObject ChooseEnemyType()
    {
        int totalWeight = 0;
        foreach (var e in enemyTypes) totalWeight += e.weight;

        int randomValue = Random.Range(0, totalWeight);
        foreach (var e in enemyTypes)
        {
            if (randomValue < e.weight) return e.prefab;
            randomValue -= e.weight;
        }
        return null;
    }

    public void EnemyDied()
    {
        currentEnemies--;
        if (currentEnemies < 0) currentEnemies = 0;
    }
}

// helper to track enemy death
public class EnemyTracker : MonoBehaviour
{
    private ZombieSpawner spawner;

    public void Init(ZombieSpawner spawnerRef)
    {
        spawner = spawnerRef;
    }

    void OnDestroy()
    {
        if (spawner != null)
            spawner.EnemyDied();
    }
}