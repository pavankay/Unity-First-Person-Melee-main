using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab;  // Level 1 Enemy prefab
    public GameObject prefabLevel2; // Level 2 Enemy prefab

    public float spawnInterval = 30f; // Starting time between spawns
    public float minSpawnInterval = 15f; // Minimum time between spawns
    public float intervalDecreaseFactor = 0.9f; // Rate of decreasing spawn time
    public int currentLevel = 1; // Modify this dynamically based on your game

    private Transform playerTransform; // Reference to the player transform

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player"); // Find the player GameObject by tag
        if (player != null)
        {
            playerTransform = player.transform; // Store player's transform
        }
        else
        {
            Debug.LogError("Player object not found! Make sure your player has the 'Player' tag.");
        }
        
        StartCoroutine(SpawnPrefabsContinuously());
    }

    IEnumerator SpawnPrefabsContinuously()
    {
        float currentInterval = spawnInterval;

        while (true) // Infinite loop to keep spawning
        {
            // Spawn 3 enemies per cycle
            for (int i = 0; i < 3; i++)
            {
                GameObject selectedPrefab = (Random.value < 0.5f) ? prefab : prefabLevel2; // 50% chance to spawn either

                GameObject enemyInstance = Instantiate(selectedPrefab, transform.position, Quaternion.identity);
                EnemyAiController enemyScript = enemyInstance.GetComponent<EnemyAiController>();
                if (enemyScript != null && playerTransform != null)
                {
                    enemyScript.player = playerTransform; // Assign player
                }
            }

            yield return new WaitForSeconds(currentInterval);

            // Decrease the interval but ensure it does not go below minSpawnInterval
            currentInterval = Mathf.Max(minSpawnInterval, currentInterval * intervalDecreaseFactor);
        }
    }
}
