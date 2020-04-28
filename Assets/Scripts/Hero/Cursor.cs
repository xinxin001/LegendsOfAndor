using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CodeMonkey.Utils;
using Photon.Realtime;
using Photon.Pun;

public class Cursor : MonoBehaviourPunCallbacks
{
    public Hero archer;
    public Hero dwarf;
    public Hero warrior;
    public Hero wizard;


    void Update()
    {

        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                //If something was hit, the RaycastHit2D.collider will not be null.
                if (hit.collider != null)
                {
                    print(hit.collider.gameObject.name);
                    Hero moveHero = warrior;
                    switch (PhotonNetwork.LocalPlayer.CustomProperties["Class"].ToString())
                    {
                        case "ARCHER":
                            moveHero = archer;
                            break;
                        case "DWARF":
                            moveHero = dwarf;
                            break;
                        case "WARRIOR":
                            moveHero = warrior;
                            break;
                        case "WIZARD":
                            moveHero = wizard;
                            break;
                    }

                    //Hero move
                    if (hit.collider.gameObject.tag == "Region")
                    {
                        if (moveHero.controlPrinceThorald == false)
                        {
                            moveHero.move(hit.collider.gameObject);
                        }
                        else
                        {
                            MonsterManager.princeThorald.move(hit.collider.gameObject);
                        }

                    }
                    //Pickup farmer
                    else if (hit.collider.gameObject.tag == "Farmer")
                    {
                        moveHero.pickupFarmer(hit.collider.gameObject);
                    }
                    //Pickup gold
                    else if (hit.collider.gameObject.tag == "Gold")
                    {
                        moveHero.pickupGold(hit.collider.gameObject);

                    }
                    //Empty well
                    else if (hit.collider.gameObject.tag == "Well")
                    {
                        GameObject wellRegion = hit.collider.gameObject.GetComponent<Well>().region;
                        if (moveHero.isSameRegion(wellRegion))
                        {
                            ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Well Emptied!", "Green");
                            moveHero.emptyWell(hit.collider.gameObject.GetComponent<Well>());
                        }
                    }
                    else if (hit.collider.gameObject.tag == "Merchant")
                    {
                        print("Select Merchant");
                        GameObject merchantRegion = hit.collider.gameObject.GetComponent<Merchant>().region;
                        if (moveHero.isSameRegion(merchantRegion))
                        {
                            moveHero.interactMerchant(hit.collider.gameObject.GetComponent<Merchant>());

                        }
                    }
                    else if (hit.collider.gameObject.tag == "Witch")
                    {
                        print("Select Witch");
                        GameObject witchRegion = hit.collider.gameObject.GetComponent<Witch>().region;
                        if (moveHero.isSameRegion(witchRegion))
                        {
                            moveHero.interactWitch(hit.collider.gameObject.GetComponent<Witch>());

                        }
                    }
                    else if (hit.collider.gameObject.tag == "Fog")
                    {
                        GameObject fogRegion = hit.collider.gameObject.GetComponent<Fog>().region;
                        if (moveHero.isSameRegion(fogRegion) && !hit.collider.gameObject.GetComponent<Fog>().isUsed)
                        {
                            ColorPopup.Create(UtilsClass.GetMouseWorldPosition(), "Fog", "Green");
                            moveHero.interactFog(hit.collider.gameObject.GetComponent<Fog>());
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Hero hero = warrior;
            switch (PhotonNetwork.LocalPlayer.CustomProperties["Class"].ToString())
            {
                case "ARCHER":
                    hero = archer;
                    break;
                case "DWARF":
                    hero = dwarf;
                    break;
                case "WARRIOR":
                    hero = warrior;
                    break;
                case "WIZARD":
                    hero = wizard;
                    break;
            }
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (hit.collider.gameObject.tag == "Merchant")
                {
                    print("Select Merchant");
                    GameObject merchantRegion = hit.collider.gameObject.GetComponent<Merchant>().region;
                    if (hero.isSameRegion(merchantRegion))
                    {
                        hero.buyStrength();
                    }
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            Hero hero = warrior;
            switch (PhotonNetwork.LocalPlayer.CustomProperties["Class"].ToString())
            {
                case "ARCHER":
                    hero = archer;
                    break;
                case "DWARF":
                    hero = dwarf;
                    break;
                case "WARRIOR":
                    hero = warrior;
                    break;
                case "WIZARD":
                    hero = wizard;
                    break;
            }
            hero.fight();
        }
    }
}
