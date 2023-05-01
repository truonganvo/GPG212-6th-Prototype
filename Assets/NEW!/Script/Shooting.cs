using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;

    public int maxAmmo = 20;
    public int currentAmmo;
    public float reloadTime = 1f;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
        }
    }
    public void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        currentAmmo--;
    }

}
