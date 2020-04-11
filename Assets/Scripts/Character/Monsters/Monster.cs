using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : GameUnit
{

    public static Monster Create(GameObject spawnRegion, string monsterType)
    {
        Transform monsterTransform;
        if (monsterType.Equals("Gors"))
        {
            monsterTransform = Instantiate(GameAssets.i.pfGors, spawnRegion.transform.position, Quaternion.identity);
            Gors gors = monsterTransform.GetComponent<Gors>();
            gors.currentRegion = spawnRegion;
            return gors;
        }
        else if (monsterType.Equals("Skral"))
        {
            monsterTransform = Instantiate(GameAssets.i.pfSkral, spawnRegion.transform.position, Quaternion.identity);
            Skral skral = monsterTransform.GetComponent<Skral>();
            skral.currentRegion = spawnRegion;
            return skral;
        }
        else if (monsterType.Equals("Wardrak"))
        {
            monsterTransform = Instantiate(GameAssets.i.pfWardrak, spawnRegion.transform.position, Quaternion.identity);
            Wardrak wardrak = monsterTransform.GetComponent<Wardrak>();
            wardrak.currentRegion = spawnRegion;
            return wardrak;
        } return null;
    }

    string getName()
    {
        return name;
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
