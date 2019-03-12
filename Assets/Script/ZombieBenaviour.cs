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
        player = GameObject.FindWithTag("Player");
    }
    
    private void OnTriggerStay(Collider other)
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            countdown = (float).5;

            if (other.GetComponent<Health>() != null)
            {
                //detects if the collision is with a enemy/damagable entity
                //use GetComponent to access the script and thus the health
                health = other.GetComponent<Health>();
                health.hp = health.hp - damage;
                if (health.hp <= 0)
                {
                    Destroy(other.gameObject);
                }
            }
        }
        // Update is called once per frame
    }
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
