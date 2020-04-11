using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Cursor : MonoBehaviour
{
    public Hero hero;
    
    void Update()
    {
        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name);

                //Hero move
                if (hit.collider.gameObject.tag == "Region")
                {
                    if(hero.controlPrinceThorald == false)
                    {
                        hero.move(hit.collider.gameObject);
                    } else
                    {
                        MonsterManager.princeThorald.move(hit.collider.gameObject);
                    }
                    
                }
                //Pickup farmer
                else if(hit.collider.gameObject.tag == "Farmer")
                {
                    print("Pickup farmer");
                    hero.pickupFarmer(hit.collider.gameObject);
                }
                //Pickup gold
                else if (hit.collider.gameObject.tag == "Gold")
                {
                    print("Pickup farmer");
                    hero.pickupGold(hit.collider.gameObject);

                }
                //Empty well
                else if(hit.collider.gameObject.tag == "Well")
                {
                    print("Empty Well");
                    GameObject wellRegion = hit.collider.gameObject.GetComponent<Well>().region;
                    if(hero.isSameRegion(wellRegion)) {
                        ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Well Emptied!", "Green");
                        hero.emptyWell(hit.collider.gameObject.GetComponent<Well>());
                    }
                } 
            }
        }
    }
}
