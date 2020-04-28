using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleManager : MonoBehaviour
{
    public List<Hero> fightingHeroes;
    public Monster fightingMonster;
    public Text totalAttackPowerDisplay;

    public GameObject WarriorCombat;
    public GameObject DwarfCombat;
    public GameObject WizardCombat;
    public GameObject ArcherCombat;

    public GameObject MonsterCombat;

    public int totalAttackPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fightingMonster != null)
        {
            if (fightingMonster.willpower <= 0)
            {
                MonsterManager monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
                monsterManager.DestroyMonster(fightingMonster);
                gameObject.SetActive(false);
                //open reward screen
            }
        }
        foreach(Hero hero in fightingHeroes)
        {
            if(hero.willPower <= 0 || hero.timeOfDay <= 0)
            {
                fightingHeroes.Remove(hero);
                if (hero.HeroType.Equals("Warrior"))
                {
                    WarriorCombat.SetActive(false);
                    WarriorCombat.GetComponent<HeroCombat>().hero = hero;
                }
                else if (hero.HeroType.Equals("Dwarf"))
                {
                    DwarfCombat.SetActive(false);
                    DwarfCombat.GetComponent<HeroCombat>().hero = hero;
                }
                else if (hero.HeroType.Equals("Wizard"))
                {
                    WizardCombat.SetActive(false);
                    WizardCombat.GetComponent<HeroCombat>().hero = hero;
                }
                else if (hero.HeroType.Equals("Archer"))
                {
                    ArcherCombat.SetActive(false);
                    ArcherCombat.GetComponent<HeroCombat>().hero = hero;
                }
            }
        }
        if(fightingHeroes.Count == 0)
        {
            gameObject.SetActive(false);
        }
        totalAttackPowerDisplay.text = "Attack Power: " + totalAttackPower;
    }

    public void StartNewBattle(List<Hero> heroes, Monster monster)
    {
        fightingMonster = monster;
        foreach(Hero hero in heroes)
        {
            if(hero.HeroType.Equals("Warrior"))
            {
                WarriorCombat.SetActive(true);
                WarriorCombat.GetComponent<HeroCombat>().hero = hero;
            }
            else if (hero.HeroType.Equals("Dwarf"))
            {
                DwarfCombat.SetActive(true);
                DwarfCombat.GetComponent<HeroCombat>().hero = hero;
            }
            else if (hero.HeroType.Equals("Wizard"))
            {
                WizardCombat.SetActive(true);
                WizardCombat.GetComponent<HeroCombat>().hero = hero;
            }
            else if (hero.HeroType.Equals("Archer"))
            {
                ArcherCombat.SetActive(true);
                ArcherCombat.GetComponent<HeroCombat>().hero = hero;
            }
            hero.roll = 0;
            hero.attackPower = 0;
            fightingHeroes.Add(hero);
        }
        monster.roll = 0;
        monster.attackPower = 0;
        MonsterCombat.GetComponent<MonsterCombat>().initMonsterCombat(monster);
    }
    
    void endBattle()
    {

    }

    int heroRoll()
    {
        totalAttackPower = 0;
        foreach (Hero hero in fightingHeroes)
        {
            hero.decrementTime();
            hero.roll = Random.Range(1, 6);
            hero.attackPower = hero.roll + hero.strength;
            totalAttackPower += hero.attackPower;
        }
        return totalAttackPower;
    }

    int monsterRoll()
    {
        fightingMonster.roll = Random.Range(1, 6);
        fightingMonster.attackPower = fightingMonster.roll + fightingMonster.strength;
        return fightingMonster.attackPower;
    }

    public void fightTurn()
    {
        heroRoll();
        monsterRoll();
        if(totalAttackPower < fightingMonster.attackPower)
        {
            int difference = fightingMonster.attackPower - totalAttackPower;
            foreach(Hero hero in fightingHeroes)
            {
                hero.willPower -= difference;
            }
        } else if (totalAttackPower > fightingMonster.attackPower)
        {
            int difference = totalAttackPower - fightingMonster.attackPower;
            fightingMonster.willpower -= difference;
        }
    }
}
