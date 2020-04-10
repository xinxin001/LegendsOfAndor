using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : GameUnit
{
    new string name;
    int maxWillPower;
    int maxStrength;

    void createMonster(string name)
    {
        this.name = name;
    }

    string getName()
    {
        return name;
    }

    int getMaxWillPower()
    {
        return maxWillPower;
    }

    int getMaxStrength()
    {
        return maxStrength;
    }

    void setMaxWillPower(int wp)
    {
        maxWillPower = wp;
    }

    void setMaxStrength(int sp)
    {
        maxStrength = sp;
    }

    private void Update()
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
