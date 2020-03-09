using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroKind : MonoBehaviour
{
    private int startWP;
    private int startSP;
    private string Name;


    public int getsetStartWP{
      get{
            return startWP;}
        set => startWP = 7;
    }
    public int getsetStartSP{
        get{
            return startSP;}
        set => startSP = 1;
    }
    public string getName{
        get{
            return Name;}
    }
    public void setName(string name){
        Name = name;
    }

}
