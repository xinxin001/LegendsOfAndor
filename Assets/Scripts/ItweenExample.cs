using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItweenExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.RotateTo(gameObject, iTween.Hash("y",90f,
            "delay",1f,
            "time",3f,
            "easetype", iTween.EaseType.easeInOutExpo));
    }
}