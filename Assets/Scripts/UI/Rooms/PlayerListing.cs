using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class PlayerListing : MonoBehaviour{
    [SerializeField]
    private Text _text;

    public Player Player { get; private set; }
    public bool Ready = false;

    public void SetPlayerInfo(Player player){
        Player = player;
        // Set default player class
        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable (){{"Class","NONE"}};
        Player.SetCustomProperties(hash);
        
        _text.text = player.NickName + " - " + Player.CustomProperties["Class"];
    }

    public void Update(){
        _text.text = Player.NickName + " - " + Player.CustomProperties["Class"];
    }
}
