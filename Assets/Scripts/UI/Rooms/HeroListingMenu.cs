using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class HeroListingMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject ArcherSelection;
    [SerializeField]
    private GameObject DwarfSelection;
    [SerializeField]
    private GameObject WarriorSelection;
    [SerializeField]
    private GameObject WizardSelection;
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    // class setting decorator
    private void SetClass(string toSet, Button _Button, ColorBlock _Color) {
        int output = 0;
        Player localPlayer = PhotonNetwork.LocalPlayer;
        Player[] playerList = PhotonNetwork.PlayerList;
        bool taken = false;
        foreach (Player player in playerList)
        {
            // If a player chooses his current class, he's reverted to NONE, otherwise he can't choose the selected class
            if (player.CustomProperties["Class"].Equals(toSet)){
                if (player.NickName.Equals(localPlayer.NickName)){
                    toSet = "NONE";
                    output = 1;
                } else {
                    taken = true;
                }
            }
        }

        // Update custom properties
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
        Button _Button = WarriorSelection.GetComponent<Button>();
        ColorBlock _Color =  _Button.colors;

        SetClass("WARRIOR", _Button, _Color);
    }

    public void OnClick_SelectDwarf()
    {   
        Button _Button = DwarfSelection.GetComponent<Button>();
        ColorBlock _Color =  _Button.colors;
        SetClass("DWARF", _Button, _Color);
    }

    public void OnClick_SelectWizard()
    {
        Button _Button = WizardSelection.GetComponent<Button>();
        ColorBlock _Color =  _Button.colors;
       SetClass("WIZARD", _Button, _Color);
    }

    public void OnClick_SelectArcher()
    {
        Button _Button = ArcherSelection.GetComponent<Button>();
        ColorBlock _Color =  _Button.colors;
        SetClass("ARCHER", _Button, _Color);
    }
}
