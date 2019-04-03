using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float speed;
    public float damage;	
	public float time = (float).1;
    public int pierce = 2;
    public int current = 0;
    private Health health;
    private bool trigger = true;

    private float countdown;
    // Start is called before the first frame update
    public void Start()
    {
        countdown = time;
        //set speed to "speed" in the direction of "up"
        //the bullet moves where the pointy part is facing (given that it's rotate 90* in the x axis)
        GetComponent<Rigidbody>().velocity = transform.up * speed;
        Destroy(gameObject, 10);
    }
	public void update()
	{
		GetComponent<Rigidbody>().velocity = transform.up * speed;
	}
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Barrel")
        {
            this.GetComponent<Collider>().isTrigger = trigger;
		    trigger = !trigger;
        }
        //destroys the bullet upon contact with another object/collider
        if (this.gameObject.name == "Bullet2(Clone)" && other.gameObject.tag != "Wall")
        {
            current++;
            if (current == pierce)
            {
                current = 0;
                Destroy(this.gameObject, 0.01f);
            }
        }
        else
        {
            Destroy(this.gameObject, 0.0001f);
        }
        if (other.GetComponent<Health>() != null)
        {
            //detects if the collision is with a enemy/damagable entity
            //use GetComponent to access the script and thus the health

            other.GetComponent<Health>().takeDamage(damage);
           
        }

    }

    /*
        public void OnTriggerExit(Collider other)
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                materialize();
                countdown = time;
            }
        }

        public void materialize()
        {
            this.gameObject.GetComponent<Collider>().isTrigger = false;
        }
    */
}
