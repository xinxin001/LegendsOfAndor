using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Well : MonoBehaviour
{
    private bool depleted;

    public bool getdepleted
    {
        get { return depleted; }
    }
    public bool setdepleted
    {
        set => depleted = value;
    }
}

