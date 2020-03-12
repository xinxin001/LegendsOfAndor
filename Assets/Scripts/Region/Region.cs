using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Region:MonoBehaviour
{
    public string regionId;
    public Vector3 regionCoord;
    public GameObject[] adjacentRegions;
    public GameObject nextRegion;

    public Monster[] monsters;
    public GameObject[] heros;

    //Here i switched this TELL XIN
    public Gold gold;
    public bool fountain;

    public bool isCastle;
}
