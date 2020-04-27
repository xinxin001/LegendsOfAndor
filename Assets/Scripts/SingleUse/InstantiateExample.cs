using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class InstantiateExample : MonoBehaviourPunCallbacks
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

    private void Awake()
    {
        Player localPlayer = PhotonNetwork.LocalPlayer;
        string to_use = localPlayer.CustomProperties["Class"].ToString();
        HeroDisplay heroDisplay;

        switch (to_use) {

            case "ARCHER":
                GameObject archerObj = MasterManager.NetworkInstantiate(_archer, archerStartingPos.transform.position, Quaternion.identity);
                Hero archer = archerObj.GetComponent<Hero>();
                archer.HeroName = localPlayer.CustomProperties["Class"].ToString();
                archer.currentRegion = archerStartingPos;
                heroDisplay = HeroDisplay.Create(archer);
                archerStartingPos.GetComponent<RegionHandler>().region.heros.Add(archer);

                heroManager.AddHero(archer);
                Debug.Log("Archer spawned");
                break;

            case "DWARF":
                GameObject dwarfObj = MasterManager.NetworkInstantiate(_dwarf, dwarfStartingPos.transform.position, Quaternion.identity);
                Hero dwarf = dwarfObj.GetComponent<Hero>();
                dwarf.HeroName = localPlayer.CustomProperties["Class"].ToString();
                dwarf.currentRegion = dwarfStartingPos;
                heroDisplay = HeroDisplay.Create(dwarf);
                dwarfStartingPos.GetComponent<RegionHandler>().region.heros.Add(dwarf);

                heroManager.AddHero(dwarf);
                Debug.Log("Dwarf spawned");
                break;

            case "WARRIOR":
                GameObject warriorObj = MasterManager.NetworkInstantiate(_warrior, warriorStartingPos.transform.position, Quaternion.identity);
                Hero warrior = warriorObj.GetComponent<Hero>();
                warrior.HeroName = localPlayer.CustomProperties["Class"].ToString();
                warrior.currentRegion = warriorStartingPos;
                heroDisplay = HeroDisplay.Create(warrior);
                warriorStartingPos.GetComponent<RegionHandler>().region.heros.Add(warrior);

                heroManager.AddHero(warrior);
                Debug.Log("Warrior spawned");
                break;

            case "WIZARD":
                GameObject wizardObj = MasterManager.NetworkInstantiate(_wizard, wizardStartingPos.transform.position, Quaternion.identity);
                Hero wizard = wizardObj.GetComponent<Hero>();
                wizard.HeroName = localPlayer.CustomProperties["Class"].ToString();
                wizard.currentRegion = wizardStartingPos;
                heroDisplay = HeroDisplay.Create(wizard);
                wizardStartingPos.GetComponent<RegionHandler>().region.heros.Add(wizard);

                heroManager.AddHero(wizard);
                Debug.Log("Wizard spawned");
                break;

        }
    }

}
