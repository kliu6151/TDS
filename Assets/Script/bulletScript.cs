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
        Destroy(this.gameObject);
        //set speed to "speed" in the direction of "up"
        //the bullet moves where the pointy part is facing (given that it's rotate 90* in the x axis)
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.up * speed;
        
        //detects if the collision is with a enemy/damagable entity
        if(other.tag == tag)
        {
            //use GetComponent to access the script and thus the health
            health = other. GetComponent<Health>();
            health.hp = health.hp - damage;
            if(health.hp <=0)
            {
                Destroy(other.gameObject);
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //destroys the bullet upon contact with another object/collider
        Destroy(this.gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
