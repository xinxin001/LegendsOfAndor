using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public GameObject region;

    void Update()
    {
    }

    public static Farmer Create(GameObject createRegion)
    {
        Vector3 createRegionPosition = createRegion.transform.position;
        Transform farmerTransform = Instantiate(GameAssets.i.pfFarmer, createRegionPosition, Quaternion.identity);
        Farmer farmer = farmerTransform.GetComponent<Farmer>();
        farmer.region = createRegion;
        return farmer;
    }
}
