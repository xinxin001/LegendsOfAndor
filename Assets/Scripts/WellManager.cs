using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellManager : MonoBehaviour
{
    public List<Well> Wells;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void refillAllWells()
    {
        for(int i=0; i<Wells.ToArray().Length; i++)
        {
            Wells[i].isWellFull = true;
        }
    }
}
