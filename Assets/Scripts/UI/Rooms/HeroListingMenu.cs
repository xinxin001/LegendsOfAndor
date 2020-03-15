using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class HeroListingMenu : MonoBehaviour
{

    // [SerializeField]
    // private Text _text;

    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void SetClass(string toSet)
    {

        _myCustomProperties["Class"] = toSet;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
    }


    public void OnClick_SelectWarrior()
    {   
        Player localPlayer = PhotonNetwork.LocalPlayer;
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            if (player.CustomProperties["Class"].Equals("WARRIOR"))
                taken = true;
        }

        if (!taken){
            SetClass("WARRIOR");
            Debug.Log(localPlayer.NickName + " has update their class to: " + localPlayer.CustomProperties["Class"]);
        } else {
            Debug.Log("Invalid class choice");
        }
    }

    public void OnClick_SelectDwarf()
    {   
        Player localPlayer = PhotonNetwork.LocalPlayer;
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            if (player.CustomProperties["Class"].Equals("DWARF"))
                taken = true;
        }

        if (!taken){
            SetClass("DWARF");
            Debug.Log(localPlayer.NickName + " has update their class to: " + localPlayer.CustomProperties["Class"]);
        } else{
            Debug.Log("Invalid class choice");
        }
    }

    public void OnClick_SelectWizard()
    {
        Player localPlayer = PhotonNetwork.LocalPlayer;
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            if (player.CustomProperties["Class"].Equals("WIZARD"))
                taken = true;
        }

        if (!taken){
            SetClass("WIZARD");
            Debug.Log(localPlayer.NickName + " has update their class to: " + localPlayer.CustomProperties["Class"]);
        } else{
            Debug.Log("Invalid class choice");
        }
    }

    public void OnClick_SelectArcher()
    {
        Player localPlayer = PhotonNetwork.LocalPlayer;
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            if (player.CustomProperties["Class"].Equals("ARCHER"))
                taken = true;
        }

        if (!taken){
            SetClass("ARCHER");
            Debug.Log(localPlayer.NickName + " has update their class to: " + localPlayer.CustomProperties["Class"]);
        } else{
            Debug.Log("Invalid class choice");
        }
    }
}
