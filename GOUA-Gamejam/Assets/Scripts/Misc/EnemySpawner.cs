using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnInfo
    {
        public GameObject enemyPrefab;
        public int rarity;
    }

    public EnemySpawnInfo[] enemies;

    public float spawnDelay = 5.0f;
    public int maxEnemies = 10;

    private int currentEnemies = 0;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.0f, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies)
        {
            return;
        }

        // Calculate the total rarity of all enemies
        int totalRarity = 0;
        foreach (EnemySpawnInfo enemy in enemies)
        {
            totalRarity += enemy.rarity;
        }

        // Choose a random number between 1 and the total rarity
        int randomValue = Random.Range(1, totalRarity + 1);

        // Choose which enemy to spawn based on the random value
        GameObject enemyToSpawn = null;
        foreach (EnemySpawnInfo enemy in enemies)
        {
            randomValue -= enemy.rarity;
            if (randomValue <= 0)
            {
                enemyToSpawn = enemy.enemyPrefab;
                break;
            }
        }

        if (enemyToSpawn != null)
        {
            // Spawn the enemy at a random position
            Vector3 spawnPosition = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0.0f);
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

            // Increase the enemy count
            currentEnemies++;
        }
    }
}
