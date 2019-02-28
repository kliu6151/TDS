using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool isFiring;
    public bulletScript bullet;
    public float bulletSpeed;
    public float bulletDelay;
    private float countdown;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = bulletDelay;
                bulletScript bulletCloning = Instantiate(bullet, firePoint.position, firePoint.rotation) as bulletScript;
                bulletCloning.speed = bulletSpeed;
                Destroy(gameObject, 3);

            }
        }
        else
            countdown = 0;
    }
}
