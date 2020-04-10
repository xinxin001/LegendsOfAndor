using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlePopupScript : MonoBehaviour
{
    public GameObject battleMenuPopup;
    public Fight fight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If there are heroes inside the fight, popup the menu.
        if(fight.fightingHeroes.Length != 0 )
        {
            battleMenuPopup.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            battleMenuPopup.SetActive(false);
        }
        
    }
}
