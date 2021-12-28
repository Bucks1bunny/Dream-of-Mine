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
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
    }
    public override void Interact()
    {
        OnMouseDrag();
    }
    private void OnMouseDrag()
    {
        Vector3 f = target - transform.position;
        f = f.normalized;
        f *= force;
        rb.AddForce(f);
    }
}
