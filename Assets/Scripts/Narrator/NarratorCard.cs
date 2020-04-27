using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class NarratorCard : MonoBehaviour
{
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

    abstract public void Action();
}
