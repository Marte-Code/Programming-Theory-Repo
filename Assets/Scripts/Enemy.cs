using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float speed = 2f;

    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

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

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    public override void Attack()
    {
        Debug.Log("The Enemy attacks with a bite!");
    }
}