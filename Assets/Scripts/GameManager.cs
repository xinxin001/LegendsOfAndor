using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public MonsterManager monsterManager;
    public RegionManager regionManager;
    public WellManager wellManager;
    public HeroManager heroManager;
    public FogManager fogManager;
    public BattleManager battleManager;

    public LinkedListNode<Hero> currentTurnHero;
    public LinkedList<Hero> currentTurnOrder = new LinkedList<Hero>();
    public LinkedList<Hero> nextTurnOrder = new LinkedList<Hero>();

    public NarratorProgress Narrator;

    public Castle castle;
    public GameObject lossMenu;
    public GameObject winMenu;

    public enum GameState
    {
        HEROACTION,
        NARRATORACTION
    }

    public enum NarratorProgress
    {
        ZERO, A, B, C, D, E, F, G, H, I, J, K, L, M, N
    }
    public GameState currentGameState = GameState.HEROACTION;

    // Start is called before the first frame update
    void Start()
    {
        fogManager.randomizeFogTokens();
        newGameTurnOrder();
        Narrator = NarratorProgress.ZERO;
        NarratorEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentGameState == GameState.HEROACTION)
        {
           
        } else if(currentGameState == GameState.NARRATORACTION)
        {

        }
        if (heroManager.didDayEnd())
        {
            NarratorEvent();
            newDay();
            print("New Day!");
        }
        if(castle.CastleHealth <= 0)
        {
            gameOver();
        }
    }

    void newGameTurnOrder()
    {
        foreach(Hero hero in heroManager.heroList)
        {
            currentTurnOrder.AddLast(hero);
        }
        Hero[] orderArray = new Hero[currentTurnOrder.Count];
        currentTurnOrder.CopyTo(orderArray, 0);

        //Sort array
        int i = 1;
        while(i < orderArray.Length)
        {
            int j = i;
            while(j > 0 && orderArray[j-1].rank > orderArray[j].rank)
            {
                Hero dummy = orderArray[j];
                orderArray[j] = orderArray[j - 1];
                orderArray[j - 1] = dummy;
            }
            i++;
        }
        LinkedList<Hero> placeholder = new LinkedList<Hero>(orderArray);
        currentTurnOrder = placeholder;
        currentTurnHero = currentTurnOrder.First;
        currentTurnHero.Value.currentState = Hero.HeroState.ACTION;
    }

    void newDay()
    {
        Hero[] orderArray = new Hero[currentTurnOrder.Count];
        currentTurnOrder.CopyTo(orderArray, 0);
        foreach(Hero hero in orderArray)
        {
            nextTurnOrder.AddLast(hero);
        }
        currentTurnOrder.Clear();

        Hero[] nextOrderArray = new Hero[nextTurnOrder.Count];
        nextTurnOrder.CopyTo(nextOrderArray, 0);
        foreach (Hero hero in orderArray)
        {
            currentTurnOrder.AddLast(hero);
        }
        nextTurnOrder.Clear();

        currentTurnHero = currentTurnOrder.First;
        currentTurnHero.Value.currentState = Hero.HeroState.ACTION;
        print(currentTurnHero.Value.HeroName);
        monsterManager.moveAllMonsters();
        wellManager.refillAllWells();
        heroManager.newDay();
    }

    

    public void nextTurn()
    {
        if(currentTurnHero.Next == null)
        {
            currentTurnHero = currentTurnOrder.First;
        } else
        {
            currentTurnHero = currentTurnHero.Next;
        }
        print(currentTurnHero.Value.HeroName);
        currentTurnHero.Value.currentState = Hero.HeroState.ACTION;
        print("Next Turn!");
    }

    public void endDay()
    {
        nextTurnOrder.AddLast(currentTurnHero.Value);
        if (currentTurnHero.Next == null)
        {
            if(currentTurnOrder.Count <= 1)
            {
                currentTurnHero = currentTurnOrder.First;
            } else
            {
                currentTurnHero = currentTurnOrder.First;
                currentTurnOrder.RemoveLast();
                currentTurnHero.Value.currentState = Hero.HeroState.ACTION;
            }
        }
        else
        {
            currentTurnHero = currentTurnHero.Next;
            currentTurnOrder.Remove(currentTurnHero.Previous);
            currentTurnHero.Value.currentState = Hero.HeroState.ACTION;
        }
        print(currentTurnHero.Value.HeroName);
        print("Next Turn!");
    }

    void gameOver()
    {
        lossMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void gameWon()
    {
        winMenu.SetActive(true);
    }

    void NarratorEvent()
    {
        GameObject region8 = GameObject.Find("8");
        GameObject region20 = GameObject.Find("20");
        GameObject region21 = GameObject.Find("21");
        GameObject region26 = GameObject.Find("26");
        GameObject region27 = GameObject.Find("27");
        GameObject region48 = GameObject.Find("48");
        GameObject region19 = GameObject.Find("19");
        GameObject region7 = GameObject.Find("7");
        GameObject region14 = GameObject.Find("14");
        GameObject region25 = GameObject.Find("25");
        GameObject region34 = GameObject.Find("34");
        GameObject region24 = GameObject.Find("24");
        GameObject region36 = GameObject.Find("36");
        GameObject region56 = GameObject.Find("56");
        if(Narrator == NarratorProgress.ZERO)
        {
            Monster.Create(region8, "Gors");
            Monster.Create(region20, "Gors");
            Monster.Create(region21, "Gors");
            Monster.Create(region26, "Gors");
            Monster.Create(region48, "Gors");
            Monster.Create(region19, "Skral");
            Farmer.Create(region24);
            Narrator = NarratorProgress.A;
        }
        else if (Narrator == NarratorProgress.A)
        {
            
            Narrator = NarratorProgress.B;
        } else if( Narrator == NarratorProgress.B)
        {
            Narrator = NarratorProgress.C;
        }
        else if (Narrator == NarratorProgress.C)
        {
            Monster towerSkral = Monster.Create(region56, "Skral");
            towerSkral.strength = 30;
            Narrator = NarratorProgress.D;
        }
        else if (Narrator == NarratorProgress.D)
        {
            Narrator = NarratorProgress.E;
        }
        else if (Narrator == NarratorProgress.E)
        {
            Narrator = NarratorProgress.F;
        }
        else if (Narrator == NarratorProgress.F)
        {
            Narrator = NarratorProgress.G;
        }
        else if (Narrator == NarratorProgress.G)
        {
            Monster.Create(region26, "Wardrak");
            Monster.Create(region27, "Wardrak");
            Narrator = NarratorProgress.H;
        }
        else if (Narrator == NarratorProgress.H)
        {
            Narrator = NarratorProgress.I;
        }
        else if (Narrator == NarratorProgress.I)
        {
            Narrator = NarratorProgress.J;
        }
        else if (Narrator == NarratorProgress.J)
        {
            Narrator = NarratorProgress.K;
        }
        else if (Narrator == NarratorProgress.K)
        {
            Narrator = NarratorProgress.L;
        }
        else if (Narrator == NarratorProgress.L)
        {
            Narrator = NarratorProgress.M;
        }
        else if (Narrator == NarratorProgress.M)
        {
            Narrator = NarratorProgress.N;
        }
        else if (Narrator == NarratorProgress.N)
        {
            if(monsterManager.monsterList.Count == 0)
            {

            }
        }
    }
}
