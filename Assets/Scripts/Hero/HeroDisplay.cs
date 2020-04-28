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
    public Button controlPrinceThoraldButton;
    public GameObject goldPrefab;

    private bool wineskin = false;
    private bool helm = false;
    private bool shield = false;
    private bool falcon = false;
    private bool telescope = false;
    private bool bow = false;
    private bool brew = false;

    private int wineskinUses = 0;
    private int helmUses = 0;
    private int shieldUses = 0;
    private int falconUses = 0;
    private int telescopeUses = 0;
    private int bowUses = 0;
    private int brewUses = 0;

    private int brewCost = 3;

    private string button1Space = "empty";
    private string button2Space = "empty";
    private string button3Space = "empty";
    private string button4Space = "empty";
    private string button5Space = "empty";
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Sprite ImageWineskin;
    public Sprite ImageHelm;
    public Sprite ImageShield;
    public Sprite ImageFalcon;
    public Sprite ImageTelescope;
    public Sprite ImageBow;
    public Sprite ImageBrew;

    public static HeroDisplay Create(Hero spawnHero)
    {
        if (spawnHero.HeroType.Equals("Warrior"))
        {
            Transform pfWarriorDisplay = Instantiate(GameAssets.i.pfWarriorDisplay);
            HeroDisplay warriorDisplay = pfWarriorDisplay.GetComponent<HeroDisplay>();
            warriorDisplay.transform.SetParent(GameObject.Find("UI").transform, false);
            warriorDisplay.hero = spawnHero;
            return warriorDisplay;
        } else if (spawnHero.HeroType.Equals("Wizard"))
        {
            Transform pfWizardDisplay = Instantiate(GameAssets.i.pfWizardDisplay);
            HeroDisplay wizardDisplay = pfWizardDisplay.GetComponent<HeroDisplay>();
            wizardDisplay.transform.SetParent(GameObject.Find("UI").transform, false);
            wizardDisplay.hero = spawnHero;
            return wizardDisplay;
        } else if (spawnHero.HeroType.Equals("Dwarf"))
        {
            Transform pfDwarfDisplay = Instantiate(GameAssets.i.pfDwarfDisplay);
            HeroDisplay dwarfDisplay = pfDwarfDisplay.GetComponent<HeroDisplay>();
            dwarfDisplay.transform.SetParent(GameObject.Find("UI").transform, false);
            dwarfDisplay.hero = spawnHero;
            return dwarfDisplay;
        } else if (spawnHero.HeroType.Equals("Archer"))
        {
            Transform pfArcherDisplay = Instantiate(GameAssets.i.pfArcherDisplay);
            HeroDisplay archerDisplay = pfArcherDisplay.GetComponent<HeroDisplay>();
            archerDisplay.transform.SetParent(GameObject.Find("UI").transform, false);
            archerDisplay.hero = spawnHero;
            return archerDisplay;
        } return null;
    }

    private void Update()
    {
        strength.text = "Strength Points: " + hero.strength;
        willpower.text = "Willpower: " + hero.willPower;
        farmers.text = "Number of Farmers: " + hero.farmers;
        gold.text = "Gold : " + hero.gold;
        hours.text = "Hours Left: " + hero.timeOfDay;
        dropGoldAmount.text = "Drop Gold: " + dropGoldSlider.value;
        dropGoldSlider.maxValue = hero.gold;
        if(hero.controlPrinceThorald == true)
        {
            controlPrinceThoraldButton.GetComponent<Button>().GetComponent<Image>().color = Color.red;
        } else
        {
            controlPrinceThoraldButton.GetComponent<Button>().GetComponent<Image>().color = Color.white;
        }
        print(hero.currentState);
        Hero currentTurnHero = GameObject.Find("GameManager").GetComponent<GameManager>().currentTurnHero.Value;
        if (currentTurnHero == hero)
        {
            gameObject.GetComponent<Image>().color = Color.green;
        } else
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
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
        if((int)dropGoldSlider.value != 0)
        {
            Gold.Create(hero.currentRegion, (int)dropGoldSlider.value, goldPrefab);
            hero.gold -= (int)dropGoldSlider.value;
            ColorPopup.Create(hero.transform.position, "Hero dropped " + dropGoldSlider.value + " gold!", "Orange");
        }
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

    //Toggle Control Prince Thorald
    public void controlPrinceThorald()
    {
        hero.controlPrinceThorald = !hero.controlPrinceThorald;

    }

    public void endTurn()
    {
        hero.endTurn();
        ColorPopup.Create(hero.transform.position, "Ended Turn!", "Red");
    }

    public void endDay()
    {
        hero.endDay();
        ColorPopup.Create(hero.transform.position, "Ended Day!", "Red");
    }

    public void addWineskin()
    {
        int heroGold = hero.getGold();
        if (heroGold >= 2 && wineskin == false)
        {
            addItemSmall("wineskin");


        }
    }
    public void addTelescope()
    {
        int heroGold = hero.getGold();
        if (heroGold >= 2 && telescope == false)
        {
            addItemSmall("telescope");


        }
    }
    public void addBrew()
    {
        int heroGold = hero.getGold();
        if (heroGold >= brewCost && brew == false)
        {
            addItemSmall("brew");


        }
    }
    public void addFalcon()
    {
        int heroGold = hero.getGold();
        if (heroGold >= 2 && falcon == false)
        {
            addItemBig("falcon");


        }
    }
    public void addShield()
    {
        int heroGold = hero.getGold();
        if (heroGold >= 2 && shield == false)
        {
            addItemBig("shield");


        }
    }
    public void addBow()
    {
        int heroGold = hero.getGold();
        if (heroGold >= 2 && bow == false)
        {
            addItemBig("bow");


        }
    }
    public void addHelm()
    {
        int heroGold = hero.getGold();
        if (heroGold >= 2 && helm == false)
        {
            addItemHead("helm");


        }
    }

    public void useShield()
    {


        button3.gameObject.SetActive(false);

    }

    private void addItemSmall(string item)
    {
        int heroGold = hero.getGold();
        if (button1Space == "empty") //if button space 1 is empty, add item there
        {
            if (item == "wineskin")
            {
                wineskin = true;
                wineskinUses = 2;
                button1Space = "wineskin";
                hero.setGold(heroGold - 2);
                button1.GetComponent<Image>().sprite = ImageWineskin;
                button1.gameObject.SetActive(true);

            }
            else if (item == "brew")
            {
                brew = true;
                brewUses = 2;
                button1Space = "brew";
                hero.setGold(heroGold - brewCost);
                button1.GetComponent<Image>().sprite = ImageBrew;
                button1.gameObject.SetActive(true);
            }
            else if (item == "telescope")
            {
                telescope = true;
                telescopeUses = 1;
                button1Space = "telescope";
                hero.setGold(heroGold - 2);
                button1.GetComponent<Image>().sprite = ImageTelescope;
                button1.gameObject.SetActive(true);
            }
            else
            {
                //error
                Debug.Log("Error in HeroDisplay.cs when adding to button 1");
                Debug.Log("All item slots are filled");
            }


        }
        else if (button2Space == "empty")
        { //if button space 1 is full, checks button space 2
            if (item == "wineskin")
            {
                wineskin = true;
                wineskinUses = 2;
                button2Space = "wineskin";
                hero.setGold(heroGold - 2);
                button2.GetComponent<Image>().sprite = ImageWineskin;
                button2.gameObject.SetActive(true);

            }
            else if (item == "brew")
            {
                brew = true;
                brewUses = 2;
                button2Space = "brew";
                hero.setGold(heroGold - brewCost);
                button2.GetComponent<Image>().sprite = ImageBrew;
                button2.gameObject.SetActive(true);
            }
            else if (item == "telescope")
            {
                telescope = true;
                telescopeUses = 1;
                button2Space = "telescope";
                hero.setGold(heroGold - 2);
                button2.GetComponent<Image>().sprite = ImageTelescope;
                button2.gameObject.SetActive(true);
            }
            else
            {
                //error
                Debug.Log("Error in HeroDisplay.cs when adding to button 2");
                Debug.Log("All item slots are filled");
            }
        }
        else if (button3Space == "empty")
        {
            if (item == "wineskin")
            {
                wineskin = true;
                wineskinUses = 2;
                button3Space = "wineskin";
                hero.setGold(heroGold - 2);
                button3.GetComponent<Image>().sprite = ImageWineskin;
                button3.gameObject.SetActive(true);

            }
            else if (item == "brew")
            {
                brew = true;
                brewUses = 2;
                button3Space = "brew";
                hero.setGold(heroGold - brewCost);
                button3.GetComponent<Image>().sprite = ImageBrew;
                button3.gameObject.SetActive(true);
            }
            else if (item == "telescope")
            {
                telescope = true;
                telescopeUses = 1;
                button3Space = "telescope";
                hero.setGold(heroGold - 2);
                button3.GetComponent<Image>().sprite = ImageTelescope;
                button3.gameObject.SetActive(true);
            }
            else
            {
                //error
                Debug.Log("Error in HeroDisplay.cs when adding to button 3");
                Debug.Log("All item slots are filled");
            }
        }
        else
        {
            Debug.Log("Error in HeroDisplay.cs when adding to any small item slot");
        }

    }
    private void addItemBig(string item)
    {
        int heroGold = hero.getGold();
        if (button4Space == "empty")
        {
            if (item == "shield")
            {
                shield = true;
                shieldUses = 2;
                button4Space = "shield";
                hero.setGold(heroGold - 2);
                button4.GetComponent<Image>().sprite = ImageShield;
                button4.gameObject.SetActive(true);
            }
            else if (item == "bow")
            {
                bow = true;
                bowUses = 1;
                button4Space = "bow";
                hero.setGold(heroGold - 2);
                button4.GetComponent<Image>().sprite = ImageBow;
                button4.gameObject.SetActive(true);
            }
            else if (item == "falcon")
            {
                falcon = true;
                falconUses = 1;
                button4Space = "falcon";
                hero.setGold(heroGold - 2);
                button4.GetComponent<Image>().sprite = ImageFalcon;
                button4.gameObject.SetActive(true);
            }
            else
            {
                //error
                Debug.Log("Error in HeroDisplay.cs when adding to button 4");
                Debug.Log("All item slots are filled");
            }
        }
        else
        {
            Debug.Log("Error in HeroDisplay.cs when adding to any big item slot");
        }

    }
    private void addItemHead(string item)
    {
        int heroGold = hero.getGold();
        if (button5Space == "empty")
        {
            if (item == "helm")
            {
                helm = true;
                helmUses = 1;
                button5Space = "helm";
                hero.setGold(heroGold - 2);
                button5.GetComponent<Image>().sprite = ImageHelm;
                button5.gameObject.SetActive(true);
            }
            else
            {
                //error
                Debug.Log("Error in HeroDisplay.cs when adding to button 5");
                Debug.Log("All head item slots are filled");
            }
        }
        else
        {
            Debug.Log("Error in HeroDisplay.cs when adding to any helm item slot");
        }
    }
}
