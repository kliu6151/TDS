using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public float health = 1;
    public float explosionDmg = 50;
    public ParticleSystem particleSystem;
    public Renderer render;
    public Collider collider;
    public Collider range;
    public List <Collider> hits = new List<Collider>();
    private bool oneTime = false;
    // Start is called before the first frame update
    public void Start()
    {
        range.enabled = false;
    }

    public void OnTriggerStay(Collider other)
    {
        if(!hits.Contains(other))
        {
            hits.Add(other);
            damage(other);
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
        particleSystem.Play();
	Destroy(range, .1f);
        Destroy(gameObject, 4f);
    }

    public void damage(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(oneTime)
            {
                return;
            }
            oneTime = true;
        }
        if(other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().takeDamage(explosionDmg);
        }
    }

}