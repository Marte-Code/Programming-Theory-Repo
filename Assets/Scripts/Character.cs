using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int health = 100;

    public int Health
    {
        get { return health; }
    }

    public virtual void Attack()
    {
        Debug.Log("The character attacks!");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log(gameObject.name + " have " + health + " HP");

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " is dead!");

        Destroy(gameObject);
    }
}