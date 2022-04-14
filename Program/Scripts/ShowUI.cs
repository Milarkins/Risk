using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ShowUI : NetworkBehaviour
{
    public GameObject[] ServerOnly;
    public GameObject[] ClientOnly;

    void Start()
    {
        if(isServer)
        {
            for(int i = 0; i < ServerOnly.Length; i++)
            {
                ServerOnly[i].SetActive(true);
                Debug.Log(ServerOnly[i]);
            }
        } else
        {
            for(int i = 0; i < ServerOnly.Length; i++)
            {
                ServerOnly[i].SetActive(false);
            }
        }
        if(!isServer)
        {
            for(int i = 0; i < ClientOnly.Length; i++)
            {
                ClientOnly[i].SetActive(true);
                Debug.Log(ClientOnly[i]);
            }
        } else
        {
            for(int i = 0; i < ClientOnly.Length; i++)
            {
                ClientOnly[i].SetActive(false);
            }
        }
    }

    public void Back()
    {
        if(isServer) NetworkManager.singleton.StopHost();
        if(!isServer) NetworkManager.singleton.StopClient();
    }
}
