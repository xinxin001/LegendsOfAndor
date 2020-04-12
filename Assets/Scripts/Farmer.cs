using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public GameObject region;

    void Update()
    {
        checkMonsters();
    }

    public void checkMonsters()
    {
        Monster monster = region.GetComponent<RegionHandler>().getMonster();
        if (monster != null)
        {
            Destroy(gameObject);
        }
    }

    public static Farmer Create(GameObject createRegion)
    {
        //If it's on the Castle, it will increase Castle hp instead
        if(createRegion.GetComponent<RegionHandler>().region.regionId.Equals("0"))
        {
            createRegion.GetComponent<Castle>().CastleHealth += 1;
            ColorPopup.Create(createRegion.transform.position, "Farmer safely escorted to castle!", "Green");
            return new Farmer();
        } else
        {
            Vector3 createRegionPosition = createRegion.transform.position;
            Transform farmerTransform = Instantiate(GameAssets.i.pfFarmer, createRegionPosition, Quaternion.identity);
            Farmer farmer = farmerTransform.GetComponent<Farmer>();
            farmer.region = createRegion;
            return farmer;
        }
    }
}
