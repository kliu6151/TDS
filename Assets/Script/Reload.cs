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
	shooting.ammoBarUpdate(isReloading);
    }

	public void startReloading()
	{
		StartCoroutine(Reloading());
	}

    IEnumerator Reloading()
    {
	isReloading = true;
	yield return new WaitForSeconds(time);
	shooting.load();
	isReloading = false;
    }
}
