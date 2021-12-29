using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour 
{ 
    [Header("Interaction")]
    Camera cam;
    private float rangeToObject = 2;
    public Image interactHand;
    public Image holdTimer;
    public LayerMask objectMask;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        Raycast();
    }
    private void FixedUpdate()
    {
        Raycast();
    }
    void Raycast()
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
                    interaction.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    interactHand.enabled = false;
                    interaction.Interact();
                }
                holdTimer.fillAmount = interaction.GetHoldTime();
                break;
            default:
                throw new System.Exception("Not Interactable"); 
        }
    }
}
