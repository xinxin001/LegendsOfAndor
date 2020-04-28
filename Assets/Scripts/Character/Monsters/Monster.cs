using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : GameUnit
{
    public int strength;
    public int willpower;
    public int numberOfDice;
    public string diceType;
    public int roll;
    public int attackPower;

    public int rewardPoints;
    public static Monster Create(GameObject spawnRegion, string monsterType)
    {
        Transform monsterTransform;
        if (monsterType.Equals("Gors"))
        {
            monsterTransform = Instantiate(GameAssets.i.pfGors, spawnRegion.transform.position, Quaternion.identity);
            Gors gors = monsterTransform.GetComponent<Gors>();
            gors.currentRegion = spawnRegion;
            gors.strength = 2;
            gors.willpower = 4;
            gors.rewardPoints = 2;
            gors.numberOfDice = 2;
            gors.diceType = "Red";
            spawnRegion.GetComponent<RegionHandler>().region.monster = gors;
            return gors;
        }
        else if (monsterType.Equals("Skral"))
        {
            monsterTransform = Instantiate(GameAssets.i.pfSkral, spawnRegion.transform.position, Quaternion.identity);
            Skral skral = monsterTransform.GetComponent<Skral>();
            skral.currentRegion = spawnRegion;
            skral.strength = 6;
            skral.willpower = 6;
            skral.rewardPoints = 4;
            skral.numberOfDice = 2;
            skral.diceType = "Red";
            spawnRegion.GetComponent<RegionHandler>().region.monster = skral;
            return skral;
        }
        else if (monsterType.Equals("Wardrak"))
        {
            monsterTransform = Instantiate(GameAssets.i.pfWardrak, spawnRegion.transform.position, Quaternion.identity);
            Wardrak wardrak = monsterTransform.GetComponent<Wardrak>();
            wardrak.currentRegion = spawnRegion;
            wardrak.strength = 10;
            wardrak.willpower = 7;
            wardrak.rewardPoints = 6;
            wardrak.numberOfDice = 2;
            wardrak.diceType = "Black";
            spawnRegion.GetComponent<RegionHandler>().region.monster = wardrak;
            return wardrak;
        } return null;
    }

    string getName()
    {
        return name;
    }

    void Update()
    {
        currentRegion.GetComponent<RegionHandler>().region.monster = this;
    }

    public void move()
    {
        float speed = 10000;
        if(currentRegion.GetComponent<RegionHandler>().region.nextRegion != null)
        {
            GameObject nextRegion = currentRegion.GetComponent<RegionHandler>().region.nextRegion; //Gets next region
            currentRegion.GetComponent<RegionHandler>().region.monster = null; //Remove urself from current region
            currentRegion = nextRegion; //next region becomes current region
            if (currentRegion.GetComponent<RegionHandler>().region.monster != null) //if there's already a monster on the region, do previous steps again
            {
                move();
            }
            else //if no other monster, move there
            {
                nextRegion.GetComponent<RegionHandler>().region.monster = this;
                Vector3 target = nextRegion.transform.position;
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed * Time.deltaTime);
            }
        }
        else
        {
            print("No more next region");
        }
    }
}
