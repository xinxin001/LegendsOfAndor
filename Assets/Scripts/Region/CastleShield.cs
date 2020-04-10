using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleShield : MonoBehaviour
{
    private SpriteRenderer sprite;
    public bool broken;

    public Color32 brokenColor;
    public Color32 unbrokenColor;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if(broken)
        {
            sprite.color = brokenColor;
        } else
        {
            sprite.color = unbrokenColor;
        }
    }
}
