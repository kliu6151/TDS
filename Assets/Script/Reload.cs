using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    private float currentAmmo;
    public float ammoMax;
    private float countdown;
    void Start()
    {
        currentAmmo = ammoMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
	{
	    
	    StartCoroutine(Reloading());
	    
	}
    }
    IEnumerator Reloading()
    {
	    Debug.Log("HI");
	    yield return new WaitForSeconds(3f);
            currentAmmo = ammoMax;
            countdown = 1000;
    }
}
