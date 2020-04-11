using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public List<Hero> fightingHeroes;
    public List<Monster> monsters;
    public bool hasBattled;
    public GameObject Canvas;

    public GameObject warriorUI;
    public GameObject MageUI;
    public GameObject DwarfUI;
    public GameObject ArcherUI;


    public attackValue warrior;
    public attackValue mage;
    public attackValue monster;
    public attackValue dwarf;
    public attackValue archer;


    public int warriorAttackPower;
    public int mageAttackPower;
    public int monsterAttackPower;
    public int dwarfAttackPower;
    public int archerAttackPower;
    public int collectiveBattlePoints;

    public int willPowerHero;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            foreach (Hero hero in fightingHeroes) {
                fightingHeroes.Remove(hero);
            }
        }
        // Here we declare the UI
        foreach (Hero hero in fightingHeroes)
        {
            if (hero.HeroType == "Warrior")
            { warriorUI.SetActive(true); }

            else if (hero.HeroType == "Mage")
            { MageUI.SetActive(true); }

            else if (hero.HeroType == "Dwarf")
            { DwarfUI.SetActive(true); }

            else if (hero.HeroType == "Archer")
            { ArcherUI.SetActive(true); }
        }

        // Start battling
        foreach (Hero hero in fightingHeroes)
        {
            if (hero.HeroType == "Warrior")
            {
                if (warrior.attack.turnDone)
                {
                    willPowerHero = hero.willPower;
                    warriorAttackPower = warrior.damage + hero.maxSP;
                }
            }
            else if (hero.HeroType == "Mage")
            {
                if (mage.attack.turnDone)
                {
                    mageAttackPower = mage.damage + hero.maxSP;
                }
            }else if (hero.HeroType == "Archer")
            {
                if (archer.attack.turnDone)
                {
                    archerAttackPower = archer.damage + hero.maxSP;
                }
            }
            else if (hero.HeroType == "Dwarf")
            {
                if (dwarf.attack.turnDone)
                {
                    dwarfAttackPower = dwarf.damage + hero.maxSP;
                }
            }

        }


        foreach(Monster monster1 in monsters)
        {
            if (monster.attack.turnDone) {
                monsterAttackPower = monster.damage;
                battle();
            }
        }

       

    }

    public void battle() {
        collectiveBattlePoints = archerAttackPower + dwarfAttackPower + mageAttackPower + warriorAttackPower;
        //Here I tried to implement the logic of removing the willPower but it doesn't seem to be working.

        foreach (Monster m in monsters)
        {
            if (m.maxWillPower <= 0)
            {
                foreach (Hero hero in fightingHeroes)
                {
                    fightingHeroes.Remove(hero);
                }
            }
        }

        foreach (Hero h in fightingHeroes)
        {
            if (h.willPower <= 0)
            {
                foreach (Hero hero in fightingHeroes)
                {
                    fightingHeroes.Remove(hero);
                }
            }

        }





        if (collectiveBattlePoints > monsterAttackPower)
        {
            int difference = collectiveBattlePoints - monsterAttackPower;
            foreach (Monster m in monsters)
            {
                m.maxWillPower -= difference;
            }
        }
        else if (collectiveBattlePoints < monsterAttackPower)
        {
            int difference = monsterAttackPower - collectiveBattlePoints;
            foreach (Hero h in fightingHeroes)
            {
                h.willPower -= difference;
            }
        }
        else {
            //Do nothing
        }
    }






}


