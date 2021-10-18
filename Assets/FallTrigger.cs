using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    [SerializeField]
    public Transform start;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        other.gameObject.transform.position = start.position; 
    }
    
}
