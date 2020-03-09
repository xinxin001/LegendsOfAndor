using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int[] regionsId;

    // Hardcode 84 regions because there are 84 regions in the Andor map
    void Start() {
        regionsId = new int[84];

        for(int i=0; i < 84; i++)
        {
            regionsId[i] = i;
        }
    }
}
