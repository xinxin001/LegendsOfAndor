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
    private int wineskin;
    private int falcon;
    private int shield;
    private int bow;
    private int helm;
    private int telescope;
    private HeroKind heroKind;
    public ArrayList farmerlist = new ArrayList();

    public int getGold {
        get { return gold; }
    }
    public void setGold(int g){
        this.gold = g;
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
    public void setmaxSP(int sp){
        this.maxSP = sp;
    }
    public int getmaxSP{
        get { return maxSP; }
    }
   
    public int getSP(){
        return maxSP;
    }
    public int getrN{
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

    public int getWineskin{
        get { return wineskin; }
    }
    public void setWineskin(int ws){
        this.wineskin = ws;
    }

    public int getFalcon{
        get { return falcon; }
    }

    public void setFalcon(int f){
        this.falcon = f;
    }

    public int getShield{
        get { return shield; }
    }
    public void setShield(int s){
        this.shield = s;
    }

    public int getBow{
        get { return bow; }
    }
    public void setBow(int b){
        this.bow = b;
    }

    public int getHelm{
        get { return helm; }
    }
    public void setHelm(int h){
        this.helm = h;
    }

    public int getTelescope{
        get { return telescope; }
    }
    public void setTelescope(int t){
        this.telescope = t;
    }

}
