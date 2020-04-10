using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroDisplay : MonoBehaviour
{
    public Hero hero;

    public Text strength;
    public Text willpower;
    public Text farmers;
    public Text gold;
    public Text hours;

    public Text dropGoldAmount;
    public Slider dropGoldSlider;

    private void Update()
    {
        strength.text = "Strength Points: " + hero.strength;
        willpower.text = "Willpower: " + hero.willPower;
        farmers.text = "Number of Farmers: " + hero.farmers;
        gold.text = "Gold : " + hero.gold;
        hours.text = "Hours Left: " + hero.timeOfDay;
        dropGoldAmount.text = "Drop Gold: " + dropGoldSlider.value;
        dropGoldSlider.maxValue = hero.gold;
    }

    public void dropFarmers()
    {
        if (hero.farmers > 0)
        {
            for (int i = 0; i < hero.farmers; i++)
            {
                Farmer.Create(hero.currentRegion);
            }
            hero.farmers = 0;
            ColorPopup.Create(hero.transform.position, "Farmers dropped!", "Orange");
        } else
        {
            ColorPopup.Create(hero.transform.position, "Hero is not escorting any farmer!", "Red");
        }
    }

    public void dropGold()
    {
        Gold.Create(hero.currentRegion, (int) dropGoldSlider.value);
        hero.gold -= (int) dropGoldSlider.value;
        ColorPopup.Create(hero.transform.position, "Hero dropped " + dropGoldSlider.value + " gold!", "Orange");
    }

    public void addOvertime()
    {
        if(hero.overtime > 0 && hero.willPower > 2)
        {
            hero.timeOfDay += 1;
            hero.willPower -= 2;
            hero.overtime -= 1;
            ColorPopup.Create(hero.transform.position, "Overtime!", "Orange");
        } else if(hero.overtime <= 0)
        {
            ColorPopup.Create(hero.transform.position, "Hero is out of overtime!", "Red");
        } else if(hero.willPower <= 2)
        {
            ColorPopup.Create(hero.transform.position, "Hero does not have enough willpower!", "Red");
        }
    }
}
