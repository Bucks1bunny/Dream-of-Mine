using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public float fireRate = 1f;
    private float nextFire = 0f;
    public int maxAmmo = 7;
    private int ammo;

    public TextMeshProUGUI ammoText;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Camera playerCam;

    private void Start()
    {
        ammo = maxAmmo;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            if(ammo > 0)
            {
                nextFire = Time.time + fireRate;
                Fire();
            } else 
            {
                Debug.Log("NOT AMMO");
            }
        }

        Reload();

        ammoText.text = $"{ammo} / {maxAmmo}";
    }
    public void Fire()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bulletGO.transform.forward = playerCam.transform.forward;

        ammo -= 1;

        Destroy(bulletGO, 2f);
    }
    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ammo = maxAmmo;
    }
}
