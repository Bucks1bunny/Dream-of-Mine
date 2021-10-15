using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //   Health
    public HealthBar healthBar;
    public float maxHealth = 100;
    private float currentEnemyHealht;
    void Start()
    {
        currentEnemyHealht = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(float damage)
    {
        currentEnemyHealht -= damage;
        healthBar.SetHealth(currentEnemyHealht);

        if (currentEnemyHealht <= 0)
            Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
