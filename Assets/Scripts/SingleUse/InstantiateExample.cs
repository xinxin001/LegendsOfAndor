using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class InstantiateExample : MonoBehaviour
{
    public HeroManager heroManager;
    public GameObject archerStartingPos;
    public GameObject dwarfStartingPos;
    public GameObject warriorStartingPos;
    public GameObject wizardStartingPos;

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
        archerStartingPos = GameObject.Find("25");
        dwarfStartingPos = GameObject.Find("7");
        warriorStartingPos = GameObject.Find("14");
        wizardStartingPos = GameObject.Find("34");
        Player localPlayer = PhotonNetwork.LocalPlayer;

        string to_use = localPlayer.CustomProperties["Class"].ToString();
        HeroDisplay heroDisplay;
        GameObject heroObj;
        PhotonView photonView = PhotonView.Get(this);
        Hero hero;

        switch (to_use)
        {
            case "ARCHER":
                heroObj = MasterManager.NetworkInstantiate(_archer, archerStartingPos.transform.position, Quaternion.identity);
                hero = heroObj.GetComponent<Hero>();
                hero.HeroName = localPlayer.NickName;
                hero.currentRegion = archerStartingPos;
                heroDisplay = HeroDisplay.Create(hero);
                archerStartingPos.GetComponent<RegionHandler>().region.heros.Add(hero);
                break;
            case "DWARF":
                heroObj = MasterManager.NetworkInstantiate(_dwarf, dwarfStartingPos.transform.position, Quaternion.identity);
                hero = heroObj.GetComponent<Hero>();
                hero.HeroName = localPlayer.NickName;
                hero.currentRegion = dwarfStartingPos;
                heroDisplay = HeroDisplay.Create(hero);
                dwarfStartingPos.GetComponent<RegionHandler>().region.heros.Add(hero);
                break;
            case "WARRIOR":
                heroObj = MasterManager.NetworkInstantiate(_warrior, warriorStartingPos.transform.position, Quaternion.identity);
                hero = heroObj.GetComponent<Hero>();
                hero.HeroName = localPlayer.NickName;
                hero.currentRegion = warriorStartingPos;
                heroDisplay = HeroDisplay.Create(hero);
                warriorStartingPos.GetComponent<RegionHandler>().region.heros.Add(hero);
                break;
            case "WIZARD":
                heroObj = MasterManager.NetworkInstantiate(_wizard, wizardStartingPos.transform.position, Quaternion.identity);
                hero = heroObj.GetComponent<Hero>();
                hero.HeroName = localPlayer.NickName;
                hero.currentRegion = wizardStartingPos;
                heroDisplay = HeroDisplay.Create(hero);
                wizardStartingPos.GetComponent<RegionHandler>().region.heros.Add(hero);
                break;

        }
    }
}
