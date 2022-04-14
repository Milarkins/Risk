using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SetMap : NetworkBehaviour
{
    public GameObject[] maps;
    private GameObject map;
    [SyncVar]
    int currentMap;
    
    void Start()
    {
        GenMap();
    }

    public void GenMap()
    {
        Choose();
        Invoke("Set", 0.5f);
    }

    void Set()
    {
        Destroy(map);
        map = Instantiate(maps[currentMap]);
        map.transform.parent = this.transform;
    }

    void Choose()
    {
        if(!isServer) return;
        currentMap = Random.Range(0, maps.Length);
    }
}
