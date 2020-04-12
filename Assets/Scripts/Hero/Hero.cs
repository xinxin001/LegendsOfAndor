using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Hero : MonoBehaviour
{
    public int gold = 0;
    public int timeOfDay = 7;
    public int overtime = 3;
    public int strength = 7;
    public int willPower = 7;
    public GameObject currentRegion;
    public int farmers = 0;
    public string HeroType;

    public bool controlPrinceThorald = false;

    public GameObject MerchantDisplay;
    public GameObject WitchDisplay;

    private void Start()
    {
        
    }

    public static Hero Create(GameObject spawnRegion, string spawnHeroType)
    {
        Transform heroTransform;
        if (spawnHeroType.Equals("Warrior")){
            heroTransform = Instantiate(GameAssets.i.pfWarrior, spawnRegion.transform.position, Quaternion.identity);
            Hero warrior = heroTransform.GetComponent<Hero>();
            warrior.currentRegion = spawnRegion;
            return warrior;
        } else if(spawnHeroType.Equals("Wizard"))
        {
            heroTransform = Instantiate(GameAssets.i.pfWizard, spawnRegion.transform.position, Quaternion.identity);
            Hero wizard = heroTransform.GetComponent<Hero>();
            wizard.currentRegion = spawnRegion;
            return wizard;
        }
        else if (spawnHeroType.Equals("Dwarf"))
        {
            heroTransform = Instantiate(GameAssets.i.pfDwarf, spawnRegion.transform.position, Quaternion.identity);
            Hero dwarf = heroTransform.GetComponent<Hero>();
            dwarf.currentRegion = spawnRegion;
            return dwarf;
        }
        else if (spawnHeroType.Equals("Archer"))
        {
            heroTransform = Instantiate(GameAssets.i.pfArcher, spawnRegion.transform.position, Quaternion.identity);
            Hero archer = heroTransform.GetComponent<Hero>();
            archer.currentRegion = spawnRegion;
            return archer;
        } return null;
    }

    public int getGold()
    {
        return gold;
    }

    public void setGold(int amount)
    {
        gold = amount;
    }

    public void decrementTime()
    {
        timeOfDay = timeOfDay - 1;
    }

    public void CreateHero(){
        Hero hero = new Hero();
    }

    private void Update()
    {
        checkMonster();
    }

    //This method will check if Hero is on same region as monster
    public void checkMonster()
    {
        //Fight battleWindow = GameObject.Find("BattlePopup").GetComponent<Fight>();
        Monster monster = currentRegion.GetComponent<RegionHandler>().getMonster();
        if (monster != null)
        {
            Debug.Log("There's a monsta!");
            //Farmers get destroyed if the Hero is in the same field
            farmers = 0;
            //If you click the f key then it will initialize the fight.
            if (Input.GetKeyDown(KeyCode.F))
            {
                //battleWindow.fightingHeroes.Add(this);
                //battleWindow.monsters.Add(monster);
            }
        }
    }

    public void emptyWell(Well well)
    {
        if (HeroType.Equals("Warrior"))
        {
            willPower += 5;
        } else
        {
            willPower += 3;
        }
        well.isWellFull = false;
    }

    public void move(GameObject region)
    {
        float speed = 10000;
        if (isAdjacentRegion(region) && !isSameRegion(region))
        {
            currentRegion = region;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, region.transform.position, speed * Time.deltaTime);
            decrementTime();
        }
    }

    public void pickupFarmer(GameObject farmerObject)
    {
        GameObject farmerRegion = farmerObject.GetComponent<Farmer>().region;
        if (isSameRegion(farmerRegion))
        {
            farmers += 1;
            ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Farmer added!", "Green");
            Destroy(farmerObject);
        }
    }

    public void pickupGold(GameObject goldObject)
    {
        GameObject goldRegion = goldObject.GetComponent<Gold>().region;
        if (isSameRegion(goldRegion))
        {
            gold += goldObject.GetComponent<Gold>().amount;
            ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Gold picked up!", "Green");
            Destroy(goldObject);
        }
    }

    public void interactMerchant(Merchant merchant)
    {
        MerchantDisplay.gameObject.SetActive(true);

    }
    public void interactWitch(Witch witch)
    {
        WitchDisplay.gameObject.SetActive(true);
    }
    public void exitMerchant() //Dont think this is in use
    {
        MerchantDisplay.gameObject.SetActive(false);
    }

    public bool isAdjacentRegion(GameObject targetRegion)
    {
        string targetRegionName = targetRegion.GetComponent<RegionHandler>().region.regionId;
        GameObject[] adjacentRegions = currentRegion.GetComponent<RegionHandler>().region.adjacentRegions;
        return Array.Exists(adjacentRegions, element => element.GetComponent<RegionHandler>().region.regionId.Equals(targetRegionName));
    }

    public bool isSameRegion(GameObject targetRegion)
    {
        string targetRegionName = targetRegion.GetComponent<RegionHandler>().region.regionId;
        return currentRegion.GetComponent<RegionHandler>().region.regionId.Equals(targetRegionName);
    }
}
