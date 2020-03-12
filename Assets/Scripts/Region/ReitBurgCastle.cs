using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Here all we want to do is to open up the loss meny if Monsters overrun the castle

public class ReitBurgCastle : MonoBehaviour
{
    public GameObject lossMenu;
    
    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<RegionHandler>().getMonsters().Length > 0)
        {
            Pause();
        }
    }

    void Pause()
    {
        lossMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
