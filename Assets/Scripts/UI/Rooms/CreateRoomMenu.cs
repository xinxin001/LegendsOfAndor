using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    public void OnClick_CreateRoom()
    {
        //check if connected before creating a room

        if (!PhotonNetwork.IsConnected)
            return;
        //JoinOrCreateRoom
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        print("Created room successfully");
    }



    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Failed to create room." + message);
    }
}
