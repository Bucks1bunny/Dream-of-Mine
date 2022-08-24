using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : Interactable
{
    Rigidbody rb;
    public Transform massCenter;

    private float mouseUpDown;
    private float mouseRightLeft;
    public float force;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = massCenter.position;
        
    }
    public override void Interact()
    {
        OnMouseDrag();
    }
    private void OnMouseDrag()
    {
        mouseUpDown = Input.GetAxis("Mouse Y") * 1.5f;
        mouseRightLeft = Input.GetAxis("Mouse X") * 1.5f;

        Debug.Log("X:"+mouseRightLeft + "\nY:" + mouseUpDown);

        if (mouseRightLeft > 0)
        {
            AddForceToObject(Vector3.right);
        }

        if (mouseRightLeft < 0)
        {
            AddForceToObject(Vector3.left);
        }
        
        if (mouseUpDown > 0)
        {
            AddForceToObject(new Vector3(0, 0, 1));
        }

        if (mouseUpDown < 0)
        {
            AddForceToObject(new Vector3(0, 0, -1));
        }
    }
    void AddForceToObject(Vector3 direction)
    {
        rb.AddRelativeForce(direction * force * 0.02f, ForceMode.Impulse);
    }
}
