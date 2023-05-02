using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;

    public bool isThrowYet;

    public GameObject companion;


    private void Start()
    {
        isThrowYet = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isThrowYet)
        {
            Fire();
        }
    }
    public void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        companion.SetActive(false);
        isThrowYet = true;
    }
}
