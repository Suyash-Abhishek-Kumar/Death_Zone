using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar; // optional UI health bar

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = maxHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.value = currentHealth;

        if (currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.value = currentHealth;
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        // disable movement/shooting, trigger respawn, etc.
        gameObject.SetActive(false);
    }
}
