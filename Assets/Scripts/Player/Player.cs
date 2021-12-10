using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour,IDamageable
{
    [SerializeField] private Transform objectContainer;
    Camera cam;
    Ray ray;
    RaycastHit hit;

    public HealthBar healthBar;
    public float maxHealth = 100;
    public static float currentHealth;

    private bool b;
    private bool isCarry = false;
    private int rangeToObject = 3;
    private void Start()
    {
        b = false;
        cam = Camera.main;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        // Interaction with objects
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit, rangeToObject))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(hitObject.name);
                hitObject.GetComponent<IInteractable>().Interact();
            }
        }
        //carring objects

        if (isCarry)
            CarryObjects();
    }
    public UnityEvent PlayerPress;
    private void PressButton()
    {
         PlayerPress?.Invoke();
    }
    private void CarryObjects()
    {
        hit.rigidbody.isKinematic = !b;
        hit.collider.transform.position = objectContainer.position;
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
