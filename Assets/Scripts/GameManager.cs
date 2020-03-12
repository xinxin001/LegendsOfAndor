using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MonsterManager monsterManager;
    public RegionManager regionManager;
    public WellManager wellManager;
    public Hero warrior;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject shield1 = GameObject.Find("shield1");
        GameObject shield2 = GameObject.Find("shield2");
        if (warrior.timeOfDay <= 0)
        {
            newDay();
            print("New Day!");
            warrior.timeOfDay = 7;
        }
        if(shield1.GetComponent<RegionHandler>().region.monster != null && shield1.GetComponent<RegionHandler>().region.monster != null)
        {
            gameOver();
        }
    }

    void newDay()
    {
        monsterManager.moveAllMonsters();
        wellManager.refillAllWells();
    }

    void gameOver()
    {
        print("Game Over");
    }
}
