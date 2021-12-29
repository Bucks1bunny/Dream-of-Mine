using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour, IDamageable
{
    [Header("Health system")]
    public HealthBar healthBar;
    public float maxHealth = 100;
    public static float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Heal and Taking Damage
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
            Die();
    }
    private void Die()
    {
        Debug.Log("YOU ARE DEAD");
    }
}
