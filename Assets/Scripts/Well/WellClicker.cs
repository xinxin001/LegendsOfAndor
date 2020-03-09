using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellClicker : MonoBehaviour
{
    [SerializeField] private Material emptyColor;
    public bool empty = false;
    //public Color32 emptyColor;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && empty == false)         {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);             RaycastHit hit;              if (Physics.Raycast(ray, out hit,1000))             {                 var selection = hit.transform;                 var slectionRenderer = selection.GetComponent<Renderer>();
                 if (selection != null)
                {
                    this.GetComponent<Renderer>().material = emptyColor;
                    empty = true;
                }
            }
        }

    }
}