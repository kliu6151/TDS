using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    private GameObject prefab1;
    private GameObject prefab2;
    public bool ActiveGun1 = true;
    public bool ActiveGun2 = false;
    // Start is called before the first frame update
    void Start()
    {
        prefab1 = GameObject.FindWithTag("Gun1");
        prefab2 = GameObject.FindWithTag("Gun2");
        prefab1.SetActive(ActiveGun1);
        prefab2.SetActive(ActiveGun2);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("space"))
        {
            prefab1.SetActive(!(prefab1.activeInHierarchy));
            prefab2.SetActive(!(prefab2.activeInHierarchy));
        }
    }
}
