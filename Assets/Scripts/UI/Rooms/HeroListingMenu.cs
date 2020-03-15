using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class HeroListingMenu : MonoBehaviour
{

    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    // class setting decorator
    private void SetClass(string toSet)
    {
        Player localPlayer = PhotonNetwork.LocalPlayer;
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            if (player.CustomProperties["Class"].Equals(toSet)){
                if (player.NickName.Equals(localPlayer.NickName)){
                    toSet = "NONE";
                } else {
                    taken = true;
                }
            }
        }

        if (!taken){
            _myCustomProperties["Class"] = toSet;
            PhotonNetwork.LocalPlayer.SetCustomProperties(_myCustomProperties);
            Debug.Log(localPlayer.NickName + " has updated their class to: " + localPlayer.CustomProperties["Class"]);
        } else {
            Debug.Log("Invalid class choice");
        }
    }


    public void OnClick_SelectWarrior()
    {   
        SetClass("WARRIOR");
    }

    public void OnClick_SelectDwarf()
    {   
        SetClass("DWARF");
    }

    public void OnClick_SelectWizard()
    {
       SetClass("WIZARD");
    }

    public void OnClick_SelectArcher()
    {
        SetClass("ARCHER");
    }
}
