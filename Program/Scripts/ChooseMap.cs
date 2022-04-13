using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ChooseMap : NetworkBehaviour
{
    [SyncVar]
    public int finalIndex;

    public void Set(int Index)
    {
        finalIndex = Index;
    }
}
