using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bulletScript bullet;
    public Transform firePoint;
    public float bulletSpeed;
    public float bulletDelay;
    public float ammoHeld;


    public bool isFiring;

    private float countdown;
    private float ammo;

    private void Start()
    {
        ammo = ammoHeld;
    }
    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0 && ammo > 0)
            {
                ammo--;
                countdown = bulletDelay;
                bulletScript bulletCloning = Instantiate(bullet, firePoint.position, firePoint.rotation) as bulletScript;
                bulletCloning.speed = bulletSpeed;
            }
        }
        else
            countdown = 0;
        if (Input.GetKeyUp("r"))
        {
            ammo = ammoHeld;
        }
    }
}
