using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    private List<GameObject> PrefabList = new List<GameObject>();
    public bool ActiveGun1 = true;
    public bool ActiveGun2 = false;
    private int index;
    private int selected = 0;
    // Start is called before the first frame update
    void Start()
    {
        PrefabList.Add(GameObject.FindWithTag("Gun1"));
        PrefabList.Add(GameObject.FindWithTag("Gun2"));
        PrefabList[0].SetActive(ActiveGun1);
        PrefabList[1].SetActive(ActiveGun2);
    }
    // Update is called once per frame
    void Update()
    {
        index = PrefabList.Count;
        if(Input.GetKeyUp("space"))
        {
            PrefabList[selected].SetActive(false);
            selected++;
            if(selected == index)
            {
                selected = 0;
            }
            PrefabList[selected].SetActive(true);
        }
    }
}
