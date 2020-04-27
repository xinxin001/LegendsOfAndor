using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class InstantiateExample : MonoBehaviourPunCallbacks
{
    public HeroManager heroManager;
    public GameObject archerStartingPos = GameObject.Find("14");
    public GameObject dwarfStartingPos = GameObject.Find("7");
    public GameObject warriorStartingPos = GameObject.Find("25");
    public GameObject wizardStartingPos = GameObject.Find("34");

    [SerializeField]
    private GameObject _archer;

    [SerializeField]
    private GameObject _dwarf;

    [SerializeField]
    private GameObject _warrior;

    [SerializeField]
    private GameObject _wizard;


    private GameObject archerObj;
    private GameObject dwarfObj;
    private GameObject warriorObj;
    private GameObject wizardObj;

    private void Awake()
    {
        Player localPlayer = PhotonNetwork.LocalPlayer;
        string to_use = localPlayer.CustomProperties["Class"].ToString();
        HeroDisplay heroDisplay;
        PhotonView photonView = PhotonView.Get(this);
        Hero hero;

        switch (to_use) {

            case "ARCHER":
                archerObj = MasterManager.NetworkInstantiate(_archer, archerStartingPos.transform.position, Quaternion.identity);
                photonView.RPC("updateHero", RpcTarget.All, "ARCHER");

                hero = archerObj.GetComponent<Hero>();
                hero.currentRegion.GetComponent<RegionHandler>().region.heros.Add(hero);
                Debug.Log("Archer spawned");
                break;

            case "DWARF":
                dwarfObj = MasterManager.NetworkInstantiate(_dwarf, dwarfStartingPos.transform.position, Quaternion.identity);
                photonView.RPC("updateHero", RpcTarget.All, "DWARF");

                hero = dwarfObj.GetComponent<Hero>();
                hero.currentRegion.GetComponent<RegionHandler>().region.heros.Add(hero);
                Debug.Log("Dwarf spawned");
                break;

            case "WARRIOR":
                warriorObj = MasterManager.NetworkInstantiate(_warrior, warriorStartingPos.transform.position, Quaternion.identity);
                photonView.RPC("updateHero", RpcTarget.All, "WARRIOR");

                hero = warriorObj.GetComponent<Hero>();
                hero.currentRegion.GetComponent<RegionHandler>().region.heros.Add(hero);
                Debug.Log("Warrior spawned");
                break;

            case "WIZARD":
                wizardObj = MasterManager.NetworkInstantiate(_wizard, wizardStartingPos.transform.position, Quaternion.identity);
                photonView.RPC("updateHero", RpcTarget.All, "WIZARD");

                hero = wizardObj.GetComponent<Hero>();
                hero.currentRegion.GetComponent<RegionHandler>().region.heros.Add(hero);
                Debug.Log("Wizard spawned");
                break;
        }
    }

    [PunRPC]
    public void updateHero(string heroClass) {
        Player localPlayer = PhotonNetwork.LocalPlayer;
        Hero hero = null;
        switch (heroClass)
        {
            case "ARCHER":
                hero = archerObj.GetComponent<Hero>();
                hero.currentRegion = archerStartingPos;
                break;

            case "DWARF":
                hero = dwarfObj.GetComponent<Hero>();
                hero.currentRegion = dwarfStartingPos;
                Debug.Log("HEH");
                break;

            case "WARRIOR":
                hero = warriorObj.GetComponent<Hero>();
                hero.currentRegion = warriorStartingPos;
                break;

            case "WIZARD":
                hero = wizardObj.GetComponent<Hero>();
                hero.currentRegion = wizardStartingPos;
                break;
        }

        hero.HeroName = localPlayer.NickName;
        hero.currentRegion.GetComponent<RegionHandler>().region.heros.Add(hero);
        heroManager.AddHero(hero);
        return;
    }

}
