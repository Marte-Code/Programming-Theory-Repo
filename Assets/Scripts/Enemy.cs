using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float attackDistance = 1.5f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1f;

    private Transform player;
    private float attackTimer;

    void Start()
    {
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        attackTimer -= Time.deltaTime;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        float distance = direction.magnitude;

        if (distance > attackDistance)
        {
            transform.position +=
                direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            Attack();
        }

        if (direction != Vector3.zero)
        {
            transform.rotation =
                Quaternion.LookRotation(direction);
        }
    }

    public override void Attack()
    {
        if (attackTimer > 0f)
        {
            return;
        }

        Debug.Log("Enemy attacks Player!");

        player.GetComponent<PlayerController>()
              .TakeDamage(damage);

        attackTimer = attackCooldown;
    }

    protected override void Die()
    {
        GameManager gameManager =
            FindFirstObjectByType<GameManager>();

        if (gameManager != null)
        {
            gameManager.EnemyKilled();
        }

        Debug.Log("Enemy eliminated!");

        Destroy(gameObject);
    }
}