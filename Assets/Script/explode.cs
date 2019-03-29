using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public float health = 1;
    public float explosionDmg = 50;
    public float force;
    public ParticleSystem particleSystem;
    public Renderer render;
    public Collider collider;
    public Collider range;
    private bool oneTime = true;
    // Start is called before the first frame update
    public void Start()
    {
        range.enabled = false;
    }

    public void OnTriggerStay(Collider other)
    {
        if(health <= 0)
        { 
           if(oneTime)
           {
               particleSystem.Play();
               oneTime =  false;
               if(other.GetComponent<Health>() != null)
               {
                  other.GetComponent<Health>().takeDamage(explosionDmg);
               }
               range.enabled = false;
           }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health =- collision.gameObject.GetComponent<bulletScript>().damage;
        }
        if (health <= 0)
        {
            boom();
        }
    }

    public void boom()
    {
        health = 0;
        render.enabled = false;        
        collider.enabled = false;
        range.enabled = true;
        Destroy(gameObject, 4f);
    }

}