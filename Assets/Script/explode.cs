using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public float health = 1;
    public float explosionDmg = 50;
    public ParticleSystem particleSystem;

    public Renderer render;
    public Collider entity;
    private bool oneTime = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnTriggerStay(Collider other)
    {
        if(health <= 0)
        {
           if(oneTime)
           {
              render.enabled = false;
              entity.enabled = false;
              particleSystem.Play();
              oneTime =  !oneTime;
              if(other.GetComponent<Health>() != null)
              {
                other.GetComponent<Health>().takeDamage(explosionDmg);
              }
           }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "Barrel")
        {
            health =- collision.gameObject.GetComponent<bulletScript>().damage;
        }
        if (health <= 0)
        {
            Destroy(gameObject, 4f);
        }
    }
}