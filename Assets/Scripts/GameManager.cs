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

    public string[] Narrator;

    public Castle castle;
    public GameObject lossMenu;

    public enum GameState
    {
        HEROACTION,
        NARRATORACTION
    }
    public GameState currentGameState = GameState.HEROACTION;

    // Start is called before the first frame update
    void Start()
    {

        fogManager.randomizeFogTokens();
        newGameTurnOrder();
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
}
