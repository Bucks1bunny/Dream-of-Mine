using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable  
{
    public Rigidbody Cube;
    /*
    public override string ShowHand()
    {
        return "Press [<color=red>E</color>]";
    }
    */
    public override void Interact()
    {
        Cube.useGravity = true;
    }
}
