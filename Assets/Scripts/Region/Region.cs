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

    public Monster[] monsters;
    public GameObject[] heros;

    public int gold;
    public bool fountain;

    public bool isCastle;
}
