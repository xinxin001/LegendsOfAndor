using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public GameObject hero;
    public float speed;
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

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                hero.transform.position = Vector3.MoveTowards(hero.transform.position, target, speed * Time.deltaTime);
                Hero heroClass = hero.GetComponent<Hero>();
                heroClass.decrementTime();
                heroClass.currentRegion = hit.collider.gameObject;
            }
        }
    }
}
