using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
       [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;      // The enemy prefab
    [SerializeField] private Transform[] spawnLocations;  // Array of spawn locations

    [Header("Spawner Settings")]
    [SerializeField] private float spawnInterval = 2f;  // Time interval between spawns
    private float nextSpawnTime = 0f;

    void Update()
    {
        // Spawn the enemy at chosen intervals
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Check if spawn locations are available
        if (spawnLocations.Length == 0 || enemyPrefab == null)
        {
            Debug.LogWarning("Spawn locations or enemy prefab are missing!");
            return;
        }

        // Pick a random spawn location from the array
        Transform spawnPoint = spawnLocations[Random.Range(0, spawnLocations.Length)];

        // Instantiate the enemy at the chosen spawn location
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }



   
    
}
