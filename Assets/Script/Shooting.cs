using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool isFiring;
    public bulletScript bullet;
    public float bulletSpeed;
    public float bulletDelay;
    public float ammoMax;
    public Transform firePoint;

    private float currentAmmo;
    private float countdown;

    private void Start()
    {
        currentAmmo = ammoMax;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentAmmo = ammoMax;
            countdown = 1000;
        }
        if (isFiring)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0 && currentAmmo > 0)
            {
                currentAmmo--;
                countdown = bulletDelay;
                bulletScript bulletCloning = Instantiate(bullet, firePoint.position, firePoint.rotation) as bulletScript;
                bulletCloning.speed = bulletSpeed;  
            }
        }
        else
            countdown = 0;
    }
}
