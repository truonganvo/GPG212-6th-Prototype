using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;


    public float fireRate = 0.25f;
    public float nextFire = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }
    public void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

}
