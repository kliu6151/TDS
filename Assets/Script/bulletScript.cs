using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float speed;
    public float damage;
    public int pierce = 2;
    public int current = 0;
    private Health health;
    // Start is called before the first frame update
    void Start()
    {
        //set speed to "speed" in the direction of "up"
        //the bullet moves where the pointy part is facing (given that it's rotate 90* in the x axis)
        GetComponent<Rigidbody>().velocity = transform.up * speed;
        Destroy(gameObject, 3);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            //detects if the collision is with a enemy/damagable entity
            //use GetComponent to access the script and thus the health

            collision.gameObject.GetComponent<Health>().takeDamage(damage);
        }
        //destroys the bullet upon contact with another object/collider
        if (this.gameObject.name == "Bullet2(Clone)")
        {
            current++;
            if (current == pierce)
            {
                current = 0;
                Destroy(this.gameObject, 0.00001f);
            }
        }
        else
        {
            Destroy(this.gameObject, 0.000001f);
        }
    }
    
}
