using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{

    public List<Hero> heroList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Hero AddHero(GameObject spawnRegion, string spawnHeroType)
    {
        Hero newHero = Hero.Create(spawnRegion, spawnHeroType);
        heroList.Add(newHero);
        return newHero;
    }

    public Hero AddHero(Hero hero) {
        heroList.Add(hero);
        return hero;
    }

    public void RemoveHero(Hero hero)
    {
        heroList.Remove(hero);
        Destroy(hero);
    }

    public bool didDayEnd()
    {
        foreach(Hero hero in heroList)
        {
            if(hero.currentState != Hero.HeroState.ENDEDDAY)
            {
                return false;
            }
        }
        return true;
    }

    public void newDay()
    {
        foreach (Hero hero in heroList)
        {
            hero.refreshDay();
        }
    }
}
