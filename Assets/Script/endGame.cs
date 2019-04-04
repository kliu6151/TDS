using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    // Start is called before the first frame update
    private float hp;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hp = this.GetComponent<Health>().hp;
        if(hp <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
