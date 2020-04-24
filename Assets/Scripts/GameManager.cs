using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MonsterManager monsterManager;
    public RegionManager regionManager;
    public WellManager wellManager;

    public Hero warrior;
    public Hero wizard;
    public Hero dwarf;
    public Hero archer;

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

        warrior.timeOfDay = 7;
        warrior.overtime = 3;

        wizard.timeOfDay = 7;
        wizard.overtime = 3;

        dwarf.timeOfDay = 7;
        dwarf.overtime = 3;

        archer.timeOfDay = 7;
        archer.overtime = 3;
    }

    void gameOver()
    {
        lossMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void nextTurn()
    {
        print("Next Turn!");
    }
}
