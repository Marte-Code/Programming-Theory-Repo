using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Enemy enemy;

    [Header("Enemy Spawning")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnDistance = 10f;

    private float spawnTimer;

    void Start()
    {
        Debug.Log("=== PROGRAM OOP START===");

        Debug.Log("Player HP: " + player.Health);
        Debug.Log("Enemy HP: " + enemy.Health);

        Character character1 = player;
        Character character2 = enemy;

        //character1.Attack();
        character2.Attack();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();

        Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }

    private Vector3 GetRandomSpawnPosition()
    {
        int direction = Random.Range(0, 4);

        switch (direction)
        {
            case 0:
                // Nord
                return player.transform.position +
                       new Vector3(0, 0, spawnDistance);

            case 1:
                // Sud
                return player.transform.position +
                       new Vector3(0, 0, -spawnDistance);

            case 2:
                // Est
                return player.transform.position +
                       new Vector3(spawnDistance, 0, 0);

            default:
                // Ovest
                return player.transform.position +
                       new Vector3(-spawnDistance, 0, 0);
        }
    }
}