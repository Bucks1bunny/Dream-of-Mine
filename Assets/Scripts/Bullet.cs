using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 50f;
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(25);
            Destroy(gameObject);
        }
    }
    
}
