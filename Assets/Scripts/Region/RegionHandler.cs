using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class RegionHandler : MonoBehaviour
{
    public Region region;
    private SpriteRenderer sprite;

    public Color32 oldColor;
    public Color32 hoverColor;
    public Color32 startColor;

    //This sequences makes the selected Region get highlighted
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = startColor;
    }
    void OnMouseEnter()
    {
        oldColor = sprite.color;
        sprite.color = hoverColor;
    }
    void OnMouseExit()
    {
        sprite.color = startColor;
    }

    //This will init the region with the name of the GameObject
    void OnDrawGizmos()
    {
        region.regionId = name;
        this.tag = "Region";
    }
}
