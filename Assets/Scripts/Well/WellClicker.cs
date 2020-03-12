using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellClicker : MonoBehaviour
{
    //[SerializeField] private Material emptyColor;
    public bool empty = false;
    public Color32 emptyColor;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && empty == false)         {
            GetComponent<Renderer>().material.color= emptyColor;
            empty = true;
                
        }
    }
}