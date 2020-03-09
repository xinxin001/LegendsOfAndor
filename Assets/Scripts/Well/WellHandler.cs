using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]

public class WellHandler : MonoBehaviour
{
    public Well well;
    private SpriteRenderer sprite;
    public bool change = true;

    public Color32 oldColor;
    public Color32 hoverColor;
    public Color32 startColor;
    public Color32 emptyColor;

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
}