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
    public GameObject currentRegion;
    public ArrayList farmerlist = new ArrayList();

    public int getGold {
        get { return gold; }
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
    public void PickUpFarmer(Farmer f){
    }

    public void CreateHero(){
        Hero hero = new Hero();
    }

    public void DropFarmer(Farmer f){
        farmerlist.Remove(f);
    }

    //This method will check if Hero is on same region as monster
    public void checkMonster() {
        //Obtain list of monsters for current region:
        Monster[] monsterList = currentRegion.GetComponent<RegionHandler>().getMonsters();
        if (monsterList.Length > 0) {
            //If you click the f key then it will initialize the fight.
            if (Input.GetKeyDown(KeyCode.F)) {
                SceneManager.LoadScene(2);
            }
        }
    }


}
