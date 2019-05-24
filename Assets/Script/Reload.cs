using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
public Shooting shooting;
public bool isReloading;
    private float countdown;
    void Start()
    {
	shooting.loaded();
	isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
	{
	startReloading();
	    
	}
    }

	public void startReloading()
	{
		StartCoroutine(Reloading());
	}

    IEnumerator Reloading()
    {
	shooting.enabled = false;
	isReloading = true;
	yield return new WaitForSeconds(3f);
	shooting.enabled = true;
	shooting.loaded();
        countdown = 1000;
	isReloading = false;
    }
}
