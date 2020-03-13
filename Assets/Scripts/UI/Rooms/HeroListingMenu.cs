using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class HeroListingMenu : MonoBehaviour
{

    [SerializeField]
    private Text _text;



    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void SetClass(string toSet)
    {

        _myCustomProperties["Class"] = toSet;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
    }


    public void OnClick_SelectWarrior()
    {
        string toSet = "WARRIOR";
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            if (player.CustomProperties["Class"].Equals("WARRIOR"))
                taken = true;
        }
        if (!taken)
            SetClass("WARRIOR");

    }

    public void OnClick_SelectDwarf()
    {
        string toSet = "DWARF";
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            if (player.CustomProperties["Class"].Equals("DWARF"))
                taken = true;
        }
        if (!taken)
            SetClass("DWARF");


    }

    public void OnClick_SelectWizard()
    {
        string toSet = "WIZARD";
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            if (player.CustomProperties["Class"].Equals("WIZARD"))
                taken = true;
        }
        if (!taken)
            SetClass("WIZARD");


    }

    public void OnClick_SelectArcher()
    {
        string toSet = "ARCHER";
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            if (player.CustomProperties["Class"].Equals("ARCHER"))
                taken = true;
        }
        if (!taken)
            SetClass("ARCHER");


    }
}
