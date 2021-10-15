using UnityEngine;

public class Bandage : MonoBehaviour
{
    public float healAmount = 25f;
    Player player;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            player = collision.GetComponent<Player>();
            player.Heal(healAmount);
            Destroy(gameObject);
        }
    }
    
}
