using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBenaviour : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    private Health health;
    public float damage;
    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Health>() != null && other.tag.Equals("Player"))
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
        //destroys the bullet upon contact with another object/collider
    }
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

    }
}
