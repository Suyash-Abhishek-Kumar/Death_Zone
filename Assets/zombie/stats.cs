using UnityEngine;

public class ZombieStats : MonoBehaviour
{
    [Header("Zombie Stats")]
    public float maxHealth = 100f;
    public float moveSpeed = 3.5f;
    public float damage = 10f;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Death animation can be triggered here
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }
}
