using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCombat : MonoBehaviour
{
    public Hero hero;
    public Text diceNumber;
    public Text highestRoll;
    public Text attackPower;

    public bool rolled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        diceNumber.text = "Number of Dice: " + hero.numberOfDice;
        highestRoll.text = "Highest Roll: " + hero.roll;
        attackPower.text = "Attack Power: " + hero.attackPower;
    }

    public void exit()
    {
        BattleManager battleManager = GameObject.Find("BattleBoard").GetComponent<BattleManager>();
        battleManager.fightingHeroes.Remove(hero);
        battleManager.gameObject.SetActive(false);
    }
}
