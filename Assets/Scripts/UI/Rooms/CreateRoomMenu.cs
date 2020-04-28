using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using System.Text;
using System;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void OnClick_CreateRoom()
    {
        //check if connected before creating a room

        if (!PhotonNetwork.IsConnected){
            Debug.Log("Not connected to server");
                return;
        }
        print("Creating room.");
        //JoinOrCreateRoom
        RoomOptions options = new RoomOptions();
        options.PublishUserId = true;
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text.Trim(), options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully.", this);

        // Set the shared fog list for all players
        ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();
        // Sort the list of FogTypes
        List<string> FogTypes = new List<string>() { "EC", "EC", "EC", "EC", "EC", "SP", "WP2", "WP3", "GD", "GD", "GD", "GR", "GR", "WS", "BR" };
        var count = FogTypes.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = FogTypes[i];
            FogTypes[i] = FogTypes[r];
            FogTypes[r] = tmp;
        }
        _myCustomProperties["FogList"] = String.Join(",", FogTypes.ToArray()); ;
        PhotonNetwork.MasterClient.SetCustomProperties(_myCustomProperties);
        // Show lobby room
        _roomsCanvases.CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed: " + message, this);
    }
}
