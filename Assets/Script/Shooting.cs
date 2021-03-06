﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public bool isFiring;
    public bool loading = false;
    public bulletScript bullet;
    public float bulletSpeed;
    public float bulletDelay;
    public float ammoMax;
    public Transform firePoint;
    public Image ammoBar;
    private float currentAmmo;
    private float countdown;

    private void Start()
    {
	load();
    }

	public void load()
	{
		currentAmmo = ammoMax;
	}

	public void ammoBarUpdate(bool boolean)
	{
		if(boolean)
		{
			ammoBar.color = Color.yellow;
		}
		else
		{
			ammoBar.color = Color.blue;
		}
		loading = boolean;
	}


    // Update is called once per frame
    void Update()
    {
	if(!loading)
	{
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
		ammoBar.fillAmount = currentAmmo/ ammoMax;
	}
	ammoBar.fillAmount = currentAmmo/ ammoMax;
    }
}

