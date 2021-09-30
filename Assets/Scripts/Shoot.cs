using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public float fireRate = 1f;
    private float nextFire = 0f;
    public int maxAmmo = 7;
    private int ammo;
    private float range = 100f;

    public TextMeshProUGUI ammoText;
    //public GameObject bulletPrefab;
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
        ammo -= 1;

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
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
