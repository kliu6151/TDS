using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject[] zombies;
    public int zombLimit = 10;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
        if(zombies.Length <= zombLimit )
        {
        	this.GetComponent<Health>().enabled = true;
        	rend.material.SetColor("_Color", Color.green);
        }
        else
        {
        	this.GetComponent<Health>().enabled = false;
        	rend.material.SetColor("_Color", Color.red);
        }
    }
}
