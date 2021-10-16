using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    public Gun gunScript;
    private Transform gunContainer, player, fpsCamera;
    public Rigidbody rb;
    public BoxCollider coll;
    [SerializeField]
    private float dropForce = 5f;
    [SerializeField]
    private float pickupRange = 4f;
    [SerializeField]
    private bool equipped;
    private void Start()
    {
        gunContainer = GameObject.Find("GunContainer").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        fpsCamera = GameObject.Find("Follow camera").GetComponent<Transform>();

        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
            gunScript.enabled = false;
        }
        else
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            gunScript.enabled = true;
        }
    }
    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        if (!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E))
            Pickup();

        if (equipped && Input.GetKeyDown(KeyCode.G))
            Drop();
    }
    private void Pickup()
    {
        equipped = true;

        rb.isKinematic = true;
        coll.isTrigger = true;
        gunScript.enabled = true;

        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = new Vector3(.5f,.5f,.5f);
    }
    private void Drop()
    {
        equipped = false;

        rb.isKinematic = false;
        coll.isTrigger = false;
        gunScript.enabled = false;

        transform.SetParent(null);
        rb.AddForce(fpsCamera.forward * dropForce,ForceMode.Impulse);
    }
}
