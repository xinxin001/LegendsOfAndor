using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Hero : MonoBehaviour
{
    private int gold;
    public int timeOfDay = 7;
    public int willPower = 7;
    public int maxSP;
    public GameObject currentRegion;
    public int farmers = 0;
    public string HeroType;
    public Fight battleWindow;

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
        // -------> THIS HERE WAS THE OLD WAY OF DOING THINGS, WE HAVE OUR SPECIAL 3D FIGHT SCENE <-----------
        ////Obtain list of monsters for current region:
        //Monster monster = currentRegion.GetComponent<RegionHandler>().getMonster();
        //if (monster != null)
        //{
        //    //If you click the f key then it will initialize the fight.
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        SceneManager.LoadScene(0);
        //    }
        //}

        Monster monster = currentRegion.GetComponent<RegionHandler>().getMonster();
        if (monster != null)
        {
            //If you click the f key then it will initialize the fight.
            if (Input.GetKeyDown(KeyCode.F))
            {
                battleWindow.fightingHeroes.Add(this);
                battleWindow.monsters.Add(monster);
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

}
