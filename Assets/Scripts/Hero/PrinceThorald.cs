using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class PrinceThorald : GameUnit
{
    public int timeOfDay = 4;

    private void Update()
    {
        currentRegion.GetComponent<RegionHandler>().region.princeThorald = this;
    }

    public void move(GameObject targetRegion)
    {
        if (isAdjacentRegion(targetRegion) && !isSameRegion(targetRegion))
        {
            float speed = 10000;
            currentRegion.GetComponent<RegionHandler>().region.princeThorald = null; //Remove urself from current region
            currentRegion = targetRegion;
            Vector3 target = targetRegion.transform.position;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed * Time.deltaTime);
        }
    }

    //Checks if argument region is an adjacent region where the hero can move
    bool isAdjacentRegion(GameObject targetRegion)
    {
        string targetRegionName = targetRegion.GetComponent<RegionHandler>().region.regionId;
        GameObject[] adjacentRegions = currentRegion.GetComponent<RegionHandler>().region.adjacentRegions;
        return Array.Exists(adjacentRegions, element => element.GetComponent<RegionHandler>().region.regionId.Equals(targetRegionName));
    }

    bool isSameRegion(GameObject targetRegion)
    {
        string targetRegionName = targetRegion.GetComponent<RegionHandler>().region.regionId;
        return currentRegion.GetComponent<RegionHandler>().region.regionId.Equals(targetRegionName);
    }
}
