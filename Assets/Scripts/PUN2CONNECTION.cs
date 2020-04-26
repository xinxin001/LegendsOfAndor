using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PUN2CONNECTION : MonoBehaviourPunCallbacks
{

    [SerializeField]
    Text statusMessage;

    // Start is called before the first frame update
    private void Start(){
        print("Connecting to server.");
        statusMessage.text = "Connecting to lobby...";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster(){

        Debug.Log("Connected to Photon.", this);
        statusMessage.text = "Welcome " + MasterManager.GameSettings.NickName;
        print(PhotonNetwork.LocalPlayer.NickName);
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause){
        print("Disconnected from server for reason " + cause.ToString());
    }
}
