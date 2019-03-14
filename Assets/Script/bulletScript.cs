using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float speed;
    public float damage;
    public string tag;
    private Health health;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //set speed to "speed" in the direction of "up"
        //the bullet moves where the pointy part is facing (given that it's rotate 90* in the x axis)
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.up * speed;
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != null)

        {
            //detects if the collision is with a enemy/damagable entity
            //use GetComponent to access the script and thus the health
            Debug.Log("Bullet doing dmg");
            other.GetComponent<Health>().takeDamage(damage);
        }
        //destroys the bullet upon contact with another object/collider
        Destroy(gameObject, 0.00000000000000001f);
    }
    
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3);
    }
}
