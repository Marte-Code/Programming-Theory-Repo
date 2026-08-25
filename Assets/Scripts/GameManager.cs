using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    [Header("Enemy Spawning")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnDistance = 10f;

    private float spawnTimer;
    private bool gameOver;
    private int enemiesKilled = 0;

    public int EnemiesKilled
    {
        get { return enemiesKilled; }
    }

    void Start()
    {
        Debug.Log("=== PROGRAM OOP START ===");
    }

    void Update()
    {
        if (gameOver)
        {
            return;
        }

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
                return player.transform.position +
                       new Vector3(0, 0, spawnDistance);

            case 1:
                return player.transform.position +
                       new Vector3(0, 0, -spawnDistance);

            case 2:
                return player.transform.position +
                       new Vector3(spawnDistance, 0, 0);

            default:
                return player.transform.position +
                       new Vector3(-spawnDistance, 0, 0);
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        Debug.Log("Enemies Killed: " + enemiesKilled);
    }

    public void GameOver()
    {
        if (gameOver)
        {
            return;
        }

        gameOver = true;

        Debug.Log("======================");
        Debug.Log("      GAME OVER");
        Debug.Log("======================");
    }
}