using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject region;
    public int amount;

    void Update()
    {
    }

    public static Gold Create(GameObject createRegion, int amount)
    {
        Vector3 createRegionPosition = createRegion.transform.position;
        Transform goldTransform = Instantiate(GameAssets.i.pfGold, createRegionPosition, Quaternion.identity);
        Gold gold = goldTransform.GetComponent<Gold>();
        gold.region = createRegion;
        gold.amount = amount;
        return gold;
    }
}
