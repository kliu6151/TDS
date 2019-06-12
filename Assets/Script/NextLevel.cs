using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public static int level = 1;
    public System.Boolean manualPick;
    public int levelChoice;
    public System.Boolean disabled;
    void Start()
    {
    	   
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled && GameObject.FindWithTag("Zombie") == null)
        {
            level++;
            if (manualPick)
            {
                level = levelChoice;
            }
            SceneManager.LoadScene(level);
        }
    }
    public void next(){
	if (manualPick)
	{
		level = levelChoice;
	}
        SceneManager.LoadScene(level);
    }
}