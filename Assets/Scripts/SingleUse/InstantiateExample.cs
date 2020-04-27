using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class InstantiateExample : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private GameObject _archer;

    [SerializeField]
    private GameObject _dwarf;

    [SerializeField]
    private GameObject _warrior;

    [SerializeField]
    private GameObject _wizard;

    private void Awake()
    {
        Player localPlayer = PhotonNetwork.LocalPlayer;
        string to_use = localPlayer.CustomProperties["Class"].ToString();
        Debug.Log("CLASS: " + to_use);

        switch (to_use) {
            case "ARCHER":
                MasterManager.NetworkInstantiate(_archer, transform.position, Quaternion.identity);
                break;
            case "DWARF":
                MasterManager.NetworkInstantiate(_dwarf, transform.position, Quaternion.identity);
                break;
            case "WARRIOR":
                MasterManager.NetworkInstantiate(_warrior, transform.position, Quaternion.identity);
                break;
            case "WIZARD":
                MasterManager.NetworkInstantiate(_wizard, transform.position, Quaternion.identity);
                break;

        }
    }

}
