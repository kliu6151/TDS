using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public float spawnerDelay = 5;
    private float countdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            countdown = spawnerDelay;
            GameObject Zombie = Instantiate(Resources.Load<GameObject>("Zombie"), transform.position, transform.rotation) as GameObject;
        }
    }
}

