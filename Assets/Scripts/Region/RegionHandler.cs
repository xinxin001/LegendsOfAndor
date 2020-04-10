using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class RegionHandler : MonoBehaviour
{
    public Region region;
    private SpriteRenderer sprite;

    public Color32 startColor;
    public Color32 hoverColor;
    public Color32 mouseDownColor;


    //This sequences makes the selected Region get highlighted
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = startColor;
    }

    void OnMouseEnter()
    {
        sprite.color = hoverColor;
    }
    void OnMouseExit()
    {
        sprite.color = startColor;
    }
    void OnMouseDown()
    {
        sprite.color = mouseDownColor;
    }
    void OnMouseUp()
    {
        sprite.color = startColor;
    }

    //Method to return all the monsters for a region
    public Monster getMonster() {
        return region.monster;
    }

    public void addFarmer()
    {

    }

    public void addGoldStack()
    {

    }

    //This will init the region with the name of the GameObject
    void OnDrawGizmos()
    {
        region.regionId = name;
        region.regionCoord = GameObject.Find(name).transform.position;
    }
}
