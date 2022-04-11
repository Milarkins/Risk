using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class Transportation : NetworkBehaviour
{
    public NetworkManager manager;
    public string sceneName;
    public GameObject StartButton;
    public Button _startButton;
    public Text txt;
    private Scene scene;

    public int playersConnected;
    public int neededToStart;
 
    void Update ()
    {
        if(isServer)
        {
            scene = SceneManager.GetActiveScene();
            playersConnected = NetworkServer.connections.Count;
            if(scene.name == "Menu")
            {
                txt.text = playersConnected + "/6";
                StartButton.SetActive(true);
            } else
            {
                return;
            }
            if(playersConnected <= neededToStart - 1)//2
            {
                _startButton.interactable = false;
            } else
            {
                _startButton.interactable = true;
            }
        } else
        {
            txt.text = "waiting to start...";
            StartButton.SetActive(false);
        }
    }

    public void Tp()
    {
        if(isServer)
        {
            RpcSwitchScene();
        } else
        {
            CmdSwitchScene();
        }
    }

    [Command]
    public void CmdSwitchScene()
    {
        RpcSwitchScene();
    }
    [ClientRpc]
    public void RpcSwitchScene()
    {
        manager.ServerChangeScene(sceneName);
    }
}
