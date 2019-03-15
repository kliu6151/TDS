using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    private List<GameObject> PrefabList = new List<GameObject>();
    private int index;
    private int selected = 0;
    // Start is called before the first frame update
    void Start()
    {
        PrefabList.Add(GameObject.FindWithTag("Gun1"));
        PrefabList.Add(GameObject.FindWithTag("Gun2"));
        //PrefabList.Add(GameObject.FindWithTag("PutTagOfNewGun"));
        for (int i = 0; i<PrefabList.Count; i++)
        {
            PrefabList[i].SetActive(false);
        }
        PrefabList[0].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        index = PrefabList.Count;
        if(Input.GetKeyUp("space"))
        {
            for(int i = 0; i<PrefabList.Count; i++)
            {
                PrefabList[i].SetActive(false);
            }
            selected++;
            if(selected == index)
            {
                selected = 0;
            }
            PrefabList[selected].SetActive(true);
        }
    }
}
