using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : Interactable
{
    private Animator anim;
    private bool isClosed;

    void Start()
    {
        isClosed = true;
        anim = GetComponentInParent<Animator>();
    }
    /*
    public override string ShowHand()
    {
        return "Press [E] to open door";
    }
    */
    public override void Interact()
    {
        anim.enabled = true;
        anim.SetBool("Closed", isClosed);
        isClosed = !isClosed;
    }

}
