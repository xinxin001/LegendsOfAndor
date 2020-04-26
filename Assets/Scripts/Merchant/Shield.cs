using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool inUse;
    public int uses;


    public Shield()
    {
        inUse = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        inUse = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inUse = true;
        }
    }
}
