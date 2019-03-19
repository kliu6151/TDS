using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public float health = 1;
    public float explosionDmg = 50;
    private bool oneTime = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnTriggerStay(Collider other)
    {
        if (health <= 0)
        {
            if(oneTime)
            {
                other.GetComponent<Health>().takeDamage(explosionDmg);
                Debug.Log("once");
                oneTime =  !oneTime;
            }
            
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health =- collision.gameObject.GetComponent<bulletScript>().damage;
        }
        if (health <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
