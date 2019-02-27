using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float speed;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.up * speed;
        //set speed to "speed" in the direction of "up"
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        //destroys the bullet upon contact with another object/collider
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
