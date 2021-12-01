using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour,IInteractable  
{
    public GameObject door;

    public void Interact()
    {
        Destroy(door);
    }
}
