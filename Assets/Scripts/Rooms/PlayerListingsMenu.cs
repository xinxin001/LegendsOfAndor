using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;
    [SerializeField]
    private Text _readyUpText;

    private List<PlayerListing> _listings = new List<PlayerListing>();
    private RoomsCanvases _roomsCanvases;
    private bool _ready = false;



    public override void OnEnable()
    {
        base.OnEnable();
        SetReadyUp(false);
        GetCurrentRoomPlayers();
    }


    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < _listings.Count; i++)
            Destroy(_listings[i].gameObject);

        _listings.Clear();
    }

    private void SetReadyUp(bool state)
    {
        _ready = state;
        if (_ready)
            _readyUpText.text = "R";
        else
            _readyUpText.text = "N";
    }


    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }



    private void GetCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }

    }

    private void AddPlayerListing(Player player)
    {
        int index = _listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listings[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = Instantiate(_playerListing, _content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                _listings.Add(listing);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }


    //This will load scene at level on 1 the build order, so have to check that
    public void OnClick_StartGame()
    {
        //This means only master client can start the game, and the master client
        //is the player that creates the room
        if (PhotonNetwork.IsMasterClient)
        {

            //The first two lines are useful for ready up scenes, where you need
            //every player to be ready, and is also useful if
            //you need to not have your scenes necessarily synced up
            //for example in andor, we need to have a scene where everyone
            //can decide on their hero before the board is generated
            //Might also want to lock other people out of the room once the game
            //has started
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }


 
}
