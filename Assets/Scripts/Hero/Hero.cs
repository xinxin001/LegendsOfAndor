using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using Photon.Pun;

[System.Serializable]

public class Hero : MonoBehaviourPunCallbacks, IPunObservable
{
    public int gold = 0;
    public int timeOfDay = 7;
    public int overtime = 3;
    public int strength = 2;
    public int willPower = 7;
    public int numberOfDice;
    public int farmers = 0;
    public int rank;
    public int roll = 0;
    public int attackPower;
    
    public GameObject currentRegion;

    public string HeroType;
    public string HeroName;

    public bool controlPrinceThorald = false;

    public enum HeroState
    {
        ACTIONNEWREGION,
        ACTION,
        FIGHTING,
        WAITING,
        ENDEDDAY,
        DEAD
    }
    public HeroState currentState = HeroState.WAITING;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext(gold);
            stream.SendNext(timeOfDay);
            stream.SendNext(overtime);
            stream.SendNext(strength);
            stream.SendNext(willPower);
            stream.SendNext(numberOfDice);
            stream.SendNext(farmers);
            stream.SendNext(HeroType);
            stream.SendNext(HeroName);
            stream.SendNext(controlPrinceThorald);
            stream.SendNext(currentState);

        } else if (stream.IsReading){
            gold = (int)stream.ReceiveNext();
            timeOfDay = (int)stream.ReceiveNext();
            overtime = (int)stream.ReceiveNext();
            strength = (int)stream.ReceiveNext();
            willPower = (int)stream.ReceiveNext();
            numberOfDice = (int)stream.ReceiveNext();
            farmers = (int)stream.ReceiveNext();
            HeroType = (string)stream.ReceiveNext();
            HeroName = (string)stream.ReceiveNext();
            controlPrinceThorald = (bool)stream.ReceiveNext();
            currentState = (HeroState)stream.ReceiveNext();
        }
    }

    private void Start()
    {
        
    }

    public void Update()
    {
        checkMonster();
        if (timeOfDay <= 0)
        {
            currentState = HeroState.ENDEDDAY;
        }
        if(willPower <= 0)
        {
            currentState = HeroState.DEAD;
        }

        if(willPower > 0 && willPower <= 6)
        {
            if(HeroType == "Warrior")
            {
                numberOfDice = 2;
            } else if(HeroType == "Wizard")
            {
                numberOfDice = 1;
            } else if(HeroType == "Dwarf")
            {
                numberOfDice = 1;
            } else if(HeroType.Equals("Archer"))
            {
                numberOfDice = 3;
            }
        } else if(willPower > 6 && willPower <=13)
        {
            if (HeroType == "Warrior")
            {
                numberOfDice = 3;
            }
            else if (HeroType == "Wizard")
            {
                numberOfDice = 1;
            }
            else if (HeroType == "Dwarf")
            {
                numberOfDice = 2;
            }
            else if (HeroType.Equals("Archer"))
            {
                numberOfDice = 4;
            }
        } else if(willPower > 13)
        {
            if (HeroType == "Warrior")
            {
                numberOfDice = 4;
            }
            else if (HeroType == "Wizard")
            {
                numberOfDice = 1;
            }
            else if (HeroType == "Dwarf")
            {
                numberOfDice = 3;
            }
            else if (HeroType.Equals("Archer"))
            {
                numberOfDice = 5;
            }
        }
    }

    public static Hero Create(GameObject spawnRegion, string spawnHeroType)
    {
        Transform heroTransform;
        if (spawnHeroType.Equals("Warrior")){

            heroTransform = Instantiate(GameAssets.i.pfWarrior, spawnRegion.transform.position, Quaternion.identity);
            Hero warrior = heroTransform.GetComponent<Hero>();
            warrior.HeroName = "Thorn";
            warrior.currentRegion = spawnRegion;
            warrior.rank = 14;

            HeroDisplay heroDisplay = HeroDisplay.Create(warrior);

            spawnRegion.GetComponent<RegionHandler>().region.heros.Add(warrior);

            return warrior;

        } else if(spawnHeroType.Equals("Wizard"))
        {
            heroTransform = Instantiate(GameAssets.i.pfWizard, spawnRegion.transform.position, Quaternion.identity);
            Hero wizard = heroTransform.GetComponent<Hero>();
            wizard.HeroName = "Eara";
            wizard.currentRegion = spawnRegion;
            wizard.rank = 34;

            HeroDisplay heroDisplay = HeroDisplay.Create(wizard);

            spawnRegion.GetComponent<RegionHandler>().region.heros.Add(wizard);
            return wizard;
        }

        else if (spawnHeroType.Equals("Dwarf"))
        {
            heroTransform = Instantiate(GameAssets.i.pfDwarf, spawnRegion.transform.position, Quaternion.identity);
            Hero dwarf = heroTransform.GetComponent<Hero>();
            dwarf.HeroName = "Kram";
            dwarf.currentRegion = spawnRegion;
            dwarf.rank = 7;

            HeroDisplay heroDisplay = HeroDisplay.Create(dwarf);

            spawnRegion.GetComponent<RegionHandler>().region.heros.Add(dwarf);
            return dwarf;
        }

        else if (spawnHeroType.Equals("Archer"))
        {
            heroTransform = Instantiate(GameAssets.i.pfArcher, spawnRegion.transform.position, Quaternion.identity);
            Hero archer = heroTransform.GetComponent<Hero>();
            archer.HeroName = "Chada";
            archer.currentRegion = spawnRegion;
            archer.rank = 25;

            HeroDisplay heroDisplay = HeroDisplay.Create(archer);

            spawnRegion.GetComponent<RegionHandler>().region.heros.Add(archer);
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
        if(timeOfDay > 0)
        {
            if (isAdjacentRegion(region) && !isSameRegion(region))
            {
                currentRegion.GetComponent<RegionHandler>().region.heros.Remove(this);
                currentRegion = region;
                region.GetComponent<RegionHandler>().region.heros.Add(this);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, region.transform.position, speed * Time.deltaTime);
                decrementTime();
                currentState = HeroState.ACTIONNEWREGION;
            }
        }
        else
        {
            ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Hero has no more time left in the day!", "Red");
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
            //Destroy(goldObject);
            PhotonNetwork.Destroy(goldObject);
        }
    }

    public void interactMerchant(Merchant merchant)
    {
        if(currentState == HeroState.ACTION)
        {
            merchant.interact(this);
        } else
        {
            ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Hero has to wait a turn to interact with the Merchant", "Green");
        }
    }
    public void interactWitch(Witch witch)
    {
        if (currentState == HeroState.ACTION)
        {
            witch.interact(this);
        }
        else
        {
            ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Hero has to wait a turn to interact with the Witch", "Green");
        }
    }

    public void interactFog(Fog fog)
    {
        //Do something with fog
        fog.reveal();
        string fogType = fog.getFogType();
        if (fogType == "EC") //event card
        {
            //apply event card to game state
        }
        else if (fogType == "SP") //strengthPoint
        {
            strength++;
        }
        else if (fogType == "WP2") //WillPower +2
        {
            willPower += 2;
        }
        else if (fogType == "WP3") //WillPower +3
        {
            willPower += 3;
        }
        else if (fogType == "GD") //Gold
        {
            gold++;
        }
        else if (fogType == "GR") //Gor
        {
            // spawn gor
        }
        else if (fogType == "WS") //Wineskin
        {
            // action
        }
        else if (fogType == "BR") //Brew
        {
            // action
        }
        fog.isUsed = true;
    }

    public void refreshDay()
    {
        timeOfDay = 7;
        overtime = 3;
        currentState = HeroState.ACTION;
    }

    public void endTurn()
    {
        currentState = HeroState.WAITING;
        decrementTime();
        GameManager game = GameObject.Find("GameManager").GetComponent<GameManager>();
        game.nextTurn(); 
    }

    public void endDay()
    {
        currentState = HeroState.ENDEDDAY;
        GameManager game = GameObject.Find("GameManager").GetComponent<GameManager>();
        game.endDay();
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

    public void fight()
    {
        if(currentRegion.GetComponent<RegionHandler>().region.monster != null)
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.battleManager.gameObject.SetActive(true);
            gameManager.battleManager.StartNewBattle(currentRegion.GetComponent<RegionHandler>().region.heros, currentRegion.GetComponent<RegionHandler>().region.monster);
        }
    }

    public void buyStrength()
    {
        if(gold >= 2)
        {
            strength += 1;
            gold -= 2;
            ColorPopup.Create(gameObject.transform.position, "Bought Strength Point!", "Green");
        } else
        {
            ColorPopup.Create(gameObject.transform.position, "Not enough gold!", "Red"); ; ;
        }
    }
}
