using UnityEngine;

public class Bandage : MonoBehaviour
{
    public float healAmount = 25f;
    PlayerHealthSystem health;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            health = collision.GetComponent<PlayerHealthSystem>();
            health.Heal(healAmount);
            Destroy(gameObject);
        }
    }
    
}
