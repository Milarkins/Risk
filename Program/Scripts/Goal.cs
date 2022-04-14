using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class Goal : NetworkBehaviour
{
    public GameObject[] players;
    public float PosRad;
    private SetMap mapPick;
    
    void Start()
    {
        mapPick = GameObject.FindWithTag("Map").GetComponent<SetMap>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            players = GameObject.FindGameObjectsWithTag ("Player");
            for(int i =0; i < players.Length; i++)
            {
                StartCoroutine(tP(i));
                mapPick.GenMap();
            }
        }
    }

    IEnumerator tP(int l)
    {
        yield return new WaitForSeconds(0.5f);
        players[l].transform.position = new Vector3(Random.Range(-PosRad, PosRad), Random.Range(-PosRad, PosRad), 0f);
    }
}
