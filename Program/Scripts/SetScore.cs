using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class SetScore : NetworkBehaviour
{
    public GameObject[] players;
    public int[] playerScores;
    public Color[] playerColors;
    private string buffer = "    ";//4 Spaces
    public Text txt;
    private int scoreIndex;
    private string P1, P2, P3, P4, P5, P6;
    
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag ("Player");
        int playerAmount = players.Length;
        for(int i = 0; i < players.Length; i++)
        {
            playerScores[i] = players[i].GetComponent<PlayerScore>().score;
            playerColors[i] = players[i].GetComponent<Player>().playerColor;
            P1 = ColorUtility.ToHtmlStringRGBA( playerColors[0] );
            P2 = ColorUtility.ToHtmlStringRGBA( playerColors[1] );
            P3 = ColorUtility.ToHtmlStringRGBA( playerColors[2] );
            P4 = ColorUtility.ToHtmlStringRGBA( playerColors[3] );
            P5 = ColorUtility.ToHtmlStringRGBA( playerColors[4] );
            P6 = ColorUtility.ToHtmlStringRGBA( playerColors[5] );
            if(playerAmount == 1)
            {
                txt.text = "<color=#" + P1 + ">" + playerScores[0] + "</color>";
            }
            if(playerAmount == 2)
            {
                txt.text = "<color=#" + P1 + ">" + playerScores[0] + "</color>" + buffer + "<color=#" + P2 + ">" + playerScores[1] + "</color>";
            }
            if(playerAmount == 3)
            {
                txt.text = "<color=#" + P1 + ">" + playerScores[0] + "</color>" + buffer + "<color=#" + P2 + ">" + playerScores[1] + "</color>" + buffer + "<color=#" + P3 + ">" + playerScores[2] + "</color>";
            }
            if(playerAmount == 4)
            {
                txt.text = "<color=#" + P1 + ">" + playerScores[0] + "</color>" + buffer + "<color=#" + P2 + ">" + playerScores[1] + "</color>" + buffer + "<color=#" + P3 + ">" + playerScores[2] + "</color>" + buffer + "<color=#" + P4 + ">" + playerScores[3] + "</color>";
            }
            if(playerAmount == 5)
            {
                txt.text = "<color=#" + P1 + ">" + playerScores[0] + "</color>" + buffer + "<color=#" + P2 + ">" + playerScores[1] + "</color>" + buffer + "<color=#" + P3 + ">" + playerScores[2] + "</color>" + buffer + "<color=#" + P4 + ">" + playerScores[3] + "</color>" + buffer + "<color=#" + P5 + ">" + playerScores[4] + "</color>";
            }
            if(playerAmount == 6)
            {
                txt.text = "<color=#" + P1 + ">" + playerScores[0] + "</color>" + buffer + "<color=#" + P2 + ">" + playerScores[1] + "</color>" + buffer + "<color=#" + P3 + ">" + playerScores[2] + "</color>" + buffer + "<color=#" + P4 + ">" + playerScores[3] + "</color>" + buffer + "<color=#" + P5 + ">" + playerScores[4] + "</color>" + buffer + "<color=#" + P6 + ">" + playerScores[5] + "</color>";
            }
        }
    }
}
