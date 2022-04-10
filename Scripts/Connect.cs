using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public class Connect : MonoBehaviour
{
    public NetworkManager manager;
    public InputField nif;
    private string ipf = "localhost";
    public string GetLocalIPAddress()
     {
         var host = Dns.GetHostEntry(Dns.GetHostName());
         foreach (var ip in host.AddressList)
         {
             if (ip.AddressFamily == AddressFamily.InterNetwork)
             {
                 ipf = ip.ToString();
                 return ip.ToString();
             }
         }
         throw new System.Exception("No network adapters with an IPv4 address in the system!");
     }

    void Start()
    {
        GetLocalIPAddress();
    }

    public void Host()
    {
        manager.StartHost();
    }

    public void Join()
    {
        manager.networkAddress = ipf;
        manager.StartClient();
    }

    public void CJoin()
    {
        manager.networkAddress = nif.text;
        manager.StartClient();
    }
}
