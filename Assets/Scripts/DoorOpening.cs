using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour, IInteractable
{
    private Animator anim;
    [SerializeField] private bool isClosed = true;
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public void Interact()
    {
        isClosed = !isClosed;
        anim.SetBool("Closed", isClosed);
        anim.enabled = true;
    }
}
