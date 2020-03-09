using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Region
{
    public string regionId;
    public string[] adjacentRegionsId;
    public string nextRegionId;

    public int gold;
    public bool fountain;

    public bool isCastle;
}
