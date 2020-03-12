using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public GameObject hero;
    public float speed = 10000;
    public Vector3 target;
    
    void Update()
    {
        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            target = hit.transform.position;
            Hero heroClass = hero.GetComponent<Hero>();

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                if(hit.collider.gameObject.tag == "Region" )
                {
                    
                    heroClass.currentRegion = hit.collider.gameObject;
                    hero.transform.position = Vector3.MoveTowards(hero.transform.position, target, speed * Time.deltaTime);
                    heroClass.decrementTime();
                }
                if(hit.collider.gameObject.tag == "Sundial") // If the player clicked the Sundial, it will end his turn
                {
                    GameObject sundial = GameObject.FindGameObjectWithTag("Sundial");
                    heroClass.decrementTime();
                    print("End Turn");
                }
          
            }
        }
    }
}
