using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour,IDamageable
{

    public HealthBar healthBar;
    public float maxHealth = 100;
    public static float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) { }
    }
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
