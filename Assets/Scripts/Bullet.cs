using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletImpactPrefab;
    private float bulletSpeed = 50f;
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    { /*
        GameObject impactObject = Instantiate(bulletImpactPrefab, transform.position, Quaternion.identity);
        Destroy(impactObject, 2f);
        */
        Destroy(gameObject);
    }
}
