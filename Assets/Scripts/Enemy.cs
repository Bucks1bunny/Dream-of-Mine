using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //   Health
    public Image healthBar;
    public float health = 100;
    private float enemyHealht;
    void Start()
    {
        enemyHealht = health;
    }
    public void TakeDamage(float damage)
    {
        enemyHealht -= damage;
        healthBar.fillAmount = enemyHealht / health;

        if (enemyHealht <= 0)
            Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
