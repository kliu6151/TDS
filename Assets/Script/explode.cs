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
    private bool oneTime = true;
    // Start is called before the first frame update
    public void Start()
    {
    }

    public void OnTriggerStay(Collider other)
    {
        if(health <= 0)
        {
           if(oneTime)
           {
              particleSystem.Play();
              oneTime =  false;
			 // GetComponent<Rigidbody>().AddExplosionForce(force, GetComponent<Rigidbody>().centerOfMass, 5, 1, ForceMode.Impulse);
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
			render.enabled = false;
			collider.enabled = false;
            Destroy(gameObject, 4f);
        }
    }

}