using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class InstantiateExample : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private GameObject _prefab;

    private void Awake()
    {
        Player localPlayer = PhotonNetwork.LocalPlayer;
        bool to_ = localPlayer.CustomProperties.ContainsKey("Class");
       // string to_use = localPlayer.CustomProperties["Class"];
        GameObject _newprefab = Resources.Load("Dwarf") as GameObject;
        MasterManager.NetworkInstantiate(_prefab, transform.position, Quaternion.identity);
    }

}
