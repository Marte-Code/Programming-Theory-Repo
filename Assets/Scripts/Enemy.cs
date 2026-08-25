using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float speed = 2f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public override void Attack()
    {
        Debug.Log("Enemy attacking with bite!");
    }
}