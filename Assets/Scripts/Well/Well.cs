using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

[RequireComponent(typeof(PolygonCollider2D))]

public class Well : MonoBehaviour
{
    private SpriteRenderer sprite;
    public bool isWellFull;
    public GameObject region;


    public Color32 oldColor;
    public Color32 hoverColor;
    public Color32 startColor;
    public Color32 emptyColor;

    void Awake()
    {
        isWellFull = true;
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

    public void Update()
    {
        if(!isWellFull)
        {
            sprite.color = UtilsClass.GetColorFromString("000000");
        } else
        {
            sprite.color = startColor;
        }
    }
}
