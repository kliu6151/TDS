using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
public Shooting shooting;
public float time;
public bool isReloading = false;
    private float countdown;
    void Start()
    {
	shooting = this.gameObject.GetComponent<Shooting>();
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
public void status(bool boolean)
{

	isReloading = boolean;
	shooting.ammoBarUpdate(isReloading);
}

    IEnumerator Reloading()
    {
	status(true);
	yield return new WaitForSeconds(time);
	shooting.load();
	status(false);
    }
}
