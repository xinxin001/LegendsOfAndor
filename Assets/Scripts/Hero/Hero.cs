using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private int gold;
    private int timeOfDay;
    private bool movecomplete;
    private int maxWP;
    private int maxSP;
    private int rN;
    private HeroKind heroKind;
    public ArrayList farmerlist = new ArrayList();

    public int getGold {
        get { return gold; }
    }
    public int getTime
    {
        get { return timeOfDay; }
    }

    public bool getmoveStatus{
        get { return movecomplete; }
    }
    public int getmaxWP
    {
        get { return maxWP; }
    }
    public int getmaxSP{
        get { return maxSP; }
    }
    public int getrN
    {
        get { return rN; }
    }
    public HeroKind getHerokind{
        get { return heroKind; }
    }
    public void setHerokind(HeroKind hk){
        heroKind = hk;
    }
    public void PickUpFarmer(Farmer f){
    }

    public void CreateHero(){
        Hero hero = new Hero();
    }

    public void DropFarmer(Farmer f){
        farmerlist.Remove(f);
    }

}
