using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnMap : NetworkBehaviour
{
    [SyncVar]
    public int mapNum;
    public GameObject[] maps;

    void Start()
    {
        SetMap();
    }

    void SetMap()
    {
        if(isServer)
        {
            mapNum = Random.Range(0, maps.Length);
        }
        GameObject map = Instantiate(maps[mapNum]);
        map.transform.parent = this.transform;
    }
}
