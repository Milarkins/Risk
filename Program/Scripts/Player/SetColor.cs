using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public int playerColorNum;
    void Start()
    {
        playerColorNum = Random.Range(1, 6);
    }
}
