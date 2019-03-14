using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBenaviour : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    private Health playerHealth;
    private float health;
    public float damage;
    public float countdown = (float).5;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void takeDamage(float amount)
    {
        health -= amount;

    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Health>() != null && other.tag.Equals("Player"))
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            countdown = (float).5;

            if (other.GetComponent<Health>() != null)
            {
                //detects if the collision is with a enemy/damagable entity
                //use GetComponent to access the script and thus the health
                playerHealth = other.GetComponent<Health>();
                other.GetComponent<Health>().takeDamage(damage);
            }
        }
        // Update is called once per frame
    }
    void Update()
    {
        agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
    }
}
