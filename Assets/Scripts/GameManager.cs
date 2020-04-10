using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MonsterManager monsterManager;
    public RegionManager regionManager;
    public WellManager wellManager;
    public Hero warrior;
    public Castle castle;
    public GameObject lossMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (warrior.timeOfDay <= 0)
        {
            newDay();
            print("New Day!");
            warrior.timeOfDay = 7;
            warrior.overtime = 3;
        }
        if(castle.CastleHealth <= 0)
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
        lossMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
