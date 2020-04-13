using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LeaveRoomMenu : MonoBehaviour
{

    private RoomsCanvases _roomsCanvases;


    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Rooms");
    }


}
