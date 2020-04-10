using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Cursor : MonoBehaviour
{
    public GameObject hero;
    public float speed = 10000;
    public Vector3 target;
    
    void Update()
    {
        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            target = hit.transform.position;
            Hero heroClass = hero.GetComponent<Hero>();

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name);

                //Hero move
                if (hit.collider.gameObject.tag == "Region"  && isAdjacentRegion(hit.collider.gameObject) && !isSameRegion(hit.collider.gameObject))
                {
                    heroClass.currentRegion = hit.collider.gameObject;
                    
                    hero.transform.position = Vector3.MoveTowards(hero.transform.position, target, speed * Time.deltaTime);
                    heroClass.decrementTime();
                }
                //Hero end turn
                else if(hit.collider.gameObject.tag == "Sundial") // If the player clicked the Sundial, it will end his turn
                {
                    GameObject sundial = GameObject.FindGameObjectWithTag("Sundial");
                    heroClass.decrementTime();
                    print("End Turn");
                }
                //Pickup farmer
                else if(hit.collider.gameObject.tag == "Farmer")
                {
                    print("Pickup farmer");
                    GameObject farmerRegion = hit.collider.gameObject.GetComponent<Farmer>().region;
                    if(isSameRegion(farmerRegion))
                    {
                        heroClass.farmers += 1;
                        ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Farmer added!", "Green");
                        Destroy(hit.collider.gameObject);
                    }
                    
                }
                else if (hit.collider.gameObject.tag == "Gold")
                {
                    print("Pickup farmer");
                    GameObject goldRegion = hit.collider.gameObject.GetComponent<Gold>().region;
                    if (isSameRegion(goldRegion))
                    {
                        heroClass.gold += hit.collider.gameObject.GetComponent<Gold>().amount;
                        ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Gold picked up!", "Green");
                        Destroy(hit.collider.gameObject);
                    }

                } else if(hit.collider.gameObject.tag == "Well")
                {
                    print("Empty Well");
                    GameObject wellRegion = hit.collider.gameObject.GetComponent<Well>().region;
                    if(isSameRegion(wellRegion)) {
                        ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Well Emptied!", "Green");
                        heroClass.emptyWell(hit.collider.gameObject.GetComponent<Well>());
                    }
                } 
            }
        }
    }

    //Checks if argument region is an adjacent region where the hero can move
    bool isAdjacentRegion(GameObject targetRegion)
    {
        Hero heroClass = hero.GetComponent<Hero>();
        string targetRegionName = targetRegion.GetComponent<RegionHandler>().region.regionId;
        GameObject[] adjacentRegions = heroClass.currentRegion.GetComponent<RegionHandler>().region.adjacentRegions;
        return Array.Exists(adjacentRegions, element => element.GetComponent<RegionHandler>().region.regionId.Equals(targetRegionName));
    }
    
    bool isSameRegion(GameObject targetRegion)
    {
        Hero heroClass = hero.GetComponent<Hero>();
        string targetRegionName = targetRegion.GetComponent<RegionHandler>().region.regionId;
        return heroClass.currentRegion.GetComponent<RegionHandler>().region.regionId.Equals(targetRegionName);
    }

}
