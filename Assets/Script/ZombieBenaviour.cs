
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBenaviour : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    private Health health;
    public float damage;
    public float countdown = (float).5;

    // Start is called before the first frame update
    void Start()
    {
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<Health>() != null && other.gameObject.tag.Equals("Player"))
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = (float).5;
                //detects if the collision is with a enemy/damagable entity
                //use GetComponent to access the script and thus the health
                health = other.gameObject.GetComponent<Health>();
                health.takeDamage(damage);
            }
        }
        // Update is called once per frame
    }
    void Update()
    {
        agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
    }
}
