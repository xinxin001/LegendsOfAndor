using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _roomListing;

    [SerializeField]
    private Transform _content;


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
    }

}
