using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Hero : MonoBehaviour
{
    private int gold;
    public int timeOfDay = 7;
    public int maxWP = 7;
    private int maxSP;
<<<<<<< HEAD
    private int rN;
    private HeroKind heroKind;
    private int willPower;
=======
    public GameObject currentRegion;
>>>>>>> 256ac6e12435f5b2f3d5dc81b3be483138fa2d88
    public ArrayList farmerlist = new ArrayList();

    private void Start()
    {
        
    }

    public int getGold {
        get { return gold; }
    }
    public void addGold(int amount)
    {
        gold = gold + amount;
    }
    public int getTime
    {
        get { return timeOfDay; }
    }
    public void decrementTime()
    {
        timeOfDay = timeOfDay - 1;
    }
    public int getmaxWP
    {
        get { return maxWP; }
    }
    public void subtractMaxWP(int number)
    {
        maxWP = maxWP - number;
    }
    public int getmaxSP{
        get { return maxSP; }
    }
    public void addMaxSP(int addedSP)
    {
<<<<<<< HEAD
        get { return rN; }
    }
    public int getwiiPower
    {
        get { return willPower; }
    }

    public HeroKind getHerokind{
        get { return heroKind; }
    }
    public void setHerokind(HeroKind hk){
        heroKind = hk;
=======
        maxSP = maxSP + addedSP;
>>>>>>> 256ac6e12435f5b2f3d5dc81b3be483138fa2d88
    }
    public void PickUpFarmer(Farmer f){
    }

    public void CreateHero(){
        Hero hero = new Hero();
    }

    public void DropFarmer(Farmer f){
        farmerlist.Remove(f);
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

    //public void pickupGold()
    //{
    //    gold += currentRegion.GetComponent<Region>().gold.getGold();
    //}

}
