using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ShowUI : NetworkBehaviour
{
    public GameObject[] UIe;

    void Start()
    {
        if(isServer)
        {
            for(int i = 0; i < UIe.Length; i++)
            {
                UIe[i].SetActive(true);
                Debug.Log(UIe[i]);
            }
        } else
        {
            for(int i = 0; i < UIe.Length; i++)
            {
                UIe[i].SetActive(false);
            }
        }
    }
}
