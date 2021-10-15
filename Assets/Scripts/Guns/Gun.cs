using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public float fireRate = 1f;
    private float nextFire = 0f;
    public int maxAmmo = 7;
    private int ammo;
    private float range = 300f;

    private TextMeshProUGUI ammoText;
    private Camera playerCam;
    private Transform firePoint;

    public ParticleSystem bulletEffect;

    public bool pistol, machineGun;
    private void Start()
    {
        ammo = maxAmmo;
        ammoText = GameObject.Find("Ammo").GetComponent<TextMeshProUGUI>();
        playerCam = GameObject.Find("Follow camera").GetComponent<Camera>();
        firePoint = transform.Find("FirePoint");
    }
    private void Update()
    {
        // PISTOL
        if (pistol && Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            if(ammo > 0)
            {
                nextFire = Time.time + fireRate;
                Fire();
            }
        }
        // MACHINE GUN
        if (machineGun && Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            if (ammo > 0)
            {
                nextFire = Time.time + fireRate;
                Fire();
            }
        }

        Reload();

        ammoText.text = $"{ammo} / {maxAmmo}";
    }
    public void Fire()
    {
        ammo -= 1;
        //laser
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            IDamageable enemy = hit.transform.GetComponent<IDamageable>();
            Instantiate(bulletEffect, firePoint.position, playerCam.transform.rotation);
            if(enemy != null)
            {
                enemy.TakeDamage(25);
            }
        }
    }
    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ammo = maxAmmo;
    }
}
