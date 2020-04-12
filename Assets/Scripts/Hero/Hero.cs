using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    //public MerchantDisplay md;
    public GameObject MerchantDisplay;
    public GameObject WitchDisplay;


    private void Start()
    {
        
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
        //Obtain list of monsters for current region:
        Monster monster = currentRegion.GetComponent<RegionHandler>().getMonster();
        if (monster != null)
        {
            //If you click the f key then it will initialize the fight.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
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

    public int getGold ()
    {
        return this.gold;
    }
    public void setGold(int g)
    {
        this.gold = g;
    }
    

}
