using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CodeMonkey.Utils;

public class Cursor : MonoBehaviour
{
    public Hero hero;
    
    void Update()
    {
        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
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
                        hero.pickupFarmer(hit.collider.gameObject);
                    }
                    //Pickup gold
                    else if (hit.collider.gameObject.tag == "Gold")
                    {
                        hero.pickupGold(hit.collider.gameObject);

                    }
                    //Empty well
                    else if(hit.collider.gameObject.tag == "Well")
                    {
                        GameObject wellRegion = hit.collider.gameObject.GetComponent<Well>().region;
                        if(hero.isSameRegion(wellRegion)) {
                            ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Well Emptied!", "Green");
                            hero.emptyWell(hit.collider.gameObject.GetComponent<Well>());
                        }
                    } else if (hit.collider.gameObject.tag == "Merchant")
                    {
                        print("Select Merchant");
                        GameObject merchantRegion = hit.collider.gameObject.GetComponent<Merchant>().region;
                        if (hero.isSameRegion(merchantRegion))
                        {
                            hero.interactMerchant(hit.collider.gameObject.GetComponent<Merchant>());

                        }
                    } else if (hit.collider.gameObject.tag == "Witch")
                    {
                        print("Select Witch");
                        GameObject witchRegion = hit.collider.gameObject.GetComponent<Witch>().region;
                        if (hero.isSameRegion(witchRegion))
                        {
                            hero.interactWitch(hit.collider.gameObject.GetComponent<Witch>());

                        }
                    }
                    else if (hit.collider.gameObject.tag == "Fog")
                    {
                        GameObject fogRegion = hit.collider.gameObject.GetComponent<Fog>().region;
                        if (hero.isSameRegion(fogRegion) && !hit.collider.gameObject.GetComponent<Fog>().isUsed)
                        {
                            ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Fog", "Green");
                            hero.interactFog(hit.collider.gameObject.GetComponent<Fog>());
                        }
                    }
                }
            }
        }
    }
}
