using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpeed : MonoBehaviour
{

    public float speed;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
