using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject[] zombies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
        if(zombies.Length <= 10)
        {
        	this.GetComponent<Health>().enabled = true;
        }
    }
}
