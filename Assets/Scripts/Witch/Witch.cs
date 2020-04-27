using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
    public GameObject region;
    public GameObject warriorDisplay;
    public GameObject wizardDisplay;
    public GameObject dwarfDisplay;
    public GameObject archerDisplay;

    void Update()
    {
    }

    public static Witch Create(GameObject createRegion)
    {
        Vector3 createRegionPosition = createRegion.transform.position;
        Transform witchTransform = Instantiate(GameAssets.i.pfWitch, createRegionPosition, Quaternion.identity);
        Witch witch = witchTransform.GetComponent<Witch>();
        witch.region = createRegion;
        return witch;
    }
    public void interact(Hero hero)
    {
        warriorDisplay.SetActive(true);
    }
}
