using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : Interactable
{
    Rigidbody rb;
    private Vector3 target;
    public float force;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void Interact()
    {
        OnMouseDrag();
    }
    private void OnMouseDrag()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            rb.AddRelativeForce(Vector3.left * force * 0.02f, ForceMode.Impulse);
        }

        if (Input.GetAxis("Mouse X") < 0)
        {
            rb.AddRelativeForce(Vector3.right * force * 0.02f, ForceMode.Impulse);
        }
        
        if (Input.GetAxis("Mouse Y") > 0)
        {
            rb.AddRelativeForce(new Vector3(0,0,-1) * force * 0.02f, ForceMode.Impulse);
        }

        if (Input.GetAxis("Mouse Y") < 0)
        {
            rb.AddRelativeForce(new Vector3(0, 0, 1) * force * 0.02f, ForceMode.Impulse);
        }
    }
}
