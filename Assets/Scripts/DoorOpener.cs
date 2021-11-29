using UnityEngine.Animations;
using UnityEngine;

public class DoorOpener : MonoBehaviour, IInteractable
{
    Vector3 offset = new Vector3(0,5,0);
    void IInteractable.Interact()
    {
        transform.position = transform.position + offset;
    }

}
