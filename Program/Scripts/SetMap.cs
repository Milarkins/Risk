using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMap : MonoBehaviour
{
    public GameObject[] maps;
    private GameObject map, mapNumLib;
    private ChooseMap cm;
    
    void Start()
    {
        mapNumLib = GameObject.FindWithTag("Spawn");
        cm = mapNumLib.GetComponent<ChooseMap>();
        Destroy(map);
        map = Instantiate(maps[cm.finalIndex]);
        map.transform.parent = this.transform;
    }
}
