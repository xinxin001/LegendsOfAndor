using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour
{
    public static RegionManager instance;
    public List<GameObject> regionList = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        AddRegionData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Gets all the objects tagged "Region" in the scene
    void AddRegionData()
    {
        GameObject[] theArray = GameObject.FindGameObjectsWithTag("Region") as GameObject[];
        foreach(GameObject region in theArray)
        {
            regionList.Add(region);
        }
    }

    void InitRegions()
    {

    }
}
