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
        target = Input.mousePosition;
    }
    public override void Interact()
    {
        Vector3 f = target - transform.position;
        f = f.normalized;
        f = f * force;
        rb.AddForce(f);
    }
}
