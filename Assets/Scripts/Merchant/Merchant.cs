using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject region;

    

    void Update()
    {
    }

    public static Merchant Create(GameObject createRegion)
    {
        Vector3 createRegionPosition = createRegion.transform.position;
        Transform merchantTransform = Instantiate(GameAssets.i.pfMerchant, createRegionPosition, Quaternion.identity);
        Merchant merchant = merchantTransform.GetComponent<Merchant>();
        merchant.region = createRegion;
        return merchant;
    }
    public static void interact()
    {

    }
}
