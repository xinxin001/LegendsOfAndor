using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Region
{
    public string regionId;
    public Vector3 regionCoord;
    public GameObject[] adjacentRegions;
    public GameObject nextRegion;

    public Monster monster;
    public Farmer[] farmers;
    public Gold[] goldStacks;
    public List<Hero> heros;
    public PrinceThorald princeThorald;

    public bool fountain;
    public bool isCastle;
}
