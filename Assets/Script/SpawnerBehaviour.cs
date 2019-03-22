using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public float spawnerDelay = 5;
    public System.Boolean active;
    private float countdown;
    private System.Boolean activeTemp;
    // Start is called before the first frame update
    void Start()
    {
        activeTemp = active;
    }

    // Update is called once per frame
    void Update()
    {
        if(!active && Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) < 15)
        {
            activeTemp = true;
        }
        else
        {
            activeTemp = false;
        }
        if (activeTemp)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = spawnerDelay;
                GameObject Zombie = Instantiate(Resources.Load<GameObject>("Zombie"), transform.position, transform.rotation) as GameObject;
            }
        }
    }
}

