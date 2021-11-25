using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;

    public void DoorDestroy()
    {
        Destroy(door);
    }
}
