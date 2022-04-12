using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public int colorNum;
    public Color[] colorlist;
    void Start()
    {
        colorNum = Random.Range(0, colorlist.Length);
    }
}
