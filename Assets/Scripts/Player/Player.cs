using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Interaction")]
    Camera cam;
    private float rangeToObject = 2;
    public Image interactHand;
    public Image holdTimer;
    public LayerMask objectMask;

    [Header("Health system")]
    public HealthBar healthBar;
    public float maxHealth = 100;
    public static float currentHealth;

    private void Start()
    {
        cam = Camera.main;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    { 
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

        bool rayHit = false;

        if (Physics.Raycast(ray, out hit, rangeToObject, objectMask))
        {
            Interactable interact = hit.collider.GetComponent<Interactable>();

            if(interact != null)
            {
                rayHit = true;
                interactHand.enabled = true;
                HandleInteraction(interact);
            }
        }
        if (!rayHit) interactHand.enabled = false;
    }
    void HandleInteraction(Interactable interaction)
    {
        KeyCode key = KeyCode.E;
        switch (interaction.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key))
                {
                    interactHand.enabled = false;
                    interaction.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    interaction.IncreaseHoldTime();
                    if (interaction.GetHoldTime() > 1f)
                    {
                        interaction.Interact();
                        interaction.ResetHoldTime();
                    }
                }
                else
                    interaction.ResetHoldTime();
                holdTimer.fillAmount = interaction.GetHoldTime();
                break;
            default:
                throw new System.Exception("Not Interactable"); 
        }
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
