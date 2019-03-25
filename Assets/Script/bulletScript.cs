using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float speed;
    public float damage;	
public float time;
    public int pierce = 2;
    public int current = 0;
    private Health health;

    private float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = time;
        //set speed to "speed" in the direction of "up"
        //the bullet moves where the pointy part is facing (given that it's rotate 90* in the x axis)
        GetComponent<Rigidbody>().velocity = transform.up * speed;
        Destroy(gameObject, 2);
    }
void update()
{
//GetComponent<Rigidbody>().XRotation = 90;
}
    public void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<Collider>().isTrigger = true;
        //destroys the bullet upon contact with another object/collider
        if (this.gameObject.name == "Bullet2(Clone)" && collision.gameObject.tag != "Wall")
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
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            //detects if the collision is with a enemy/damagable entity
            //use GetComponent to access the script and thus the health

            collision.gameObject.GetComponent<Health>().takeDamage(damage);
            
        }
        
    }

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
}