using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleManager : MonoBehaviour
{
    List<Hero> fightingHeroes;
    Monster fightingMonster;
    public Text totalAttackPower;

    public GameObject WarriorCombat;
    public GameObject DwarfCombat;
    public GameObject WizardCombat;
    public GameObject ArcherCombat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartNewBattle(List<Hero> heroes, Monster monster)
    {
        foreach(Hero hero in heroes)
        {
            if(hero.HeroType.Equals("Warrior"))
            {
                WarriorCombat.SetActive(true);
            }
            else if (hero.HeroType.Equals("Dwarf"))
            {
                DwarfCombat.SetActive(true);
            }
            else if (hero.HeroType.Equals("Wizard"))
            {
                WizardCombat.SetActive(true);
            }
            else if (hero.HeroType.Equals("Archer"))
            {
                ArcherCombat.SetActive(true);
            }
        }
    }

}
