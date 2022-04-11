using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScore : NetworkBehaviour
{
    [SyncVar]
    public int score;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if(col.transform.tag == "Goal")
        {
            CmdAddPoint();
        }
    }

    [Command]
    public void CmdAddPoint()
    {
        score++;
    }
}
