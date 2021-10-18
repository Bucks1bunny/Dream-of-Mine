using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 30f;
    private Transform fpsCamera;
    public Rigidbody rb;
    private void Start()
    {
        fpsCamera = GameObject.Find("Follow camera").GetComponent<Transform>();
    }
    private void OnCollisionEnter(Collision col)
    {
        IDamageable enemy = col.gameObject.GetComponent<IDamageable>();
        if (enemy != null)
        {
            enemy.TakeDamage(25);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        rb.AddForce(fpsCamera.forward * bulletSpeed, ForceMode.Impulse);
    }
    
}
