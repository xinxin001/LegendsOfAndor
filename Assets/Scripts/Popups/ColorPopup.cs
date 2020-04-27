using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;

public class ColorPopup : MonoBehaviour
{
    //Create a red popup for Farmer Lost
    public static ColorPopup Create(Vector3 position, string popupText, string color)
    {
        Transform farmerLostPopupTransform = Instantiate(GameAssets.i.pfFarmerLostPopup, position, Quaternion.identity);
        ColorPopup farmerLost = farmerLostPopupTransform.GetComponent<ColorPopup>();
        farmerLost.Setup(popupText, color);
        return farmerLost;
    }

    private const float DISAPPEAR_TIME_MAX = 1F;

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(string popupText, string color)
    {
        textMesh.SetText(popupText);
        if(color.Equals("Red"))
        {
            //Set Text color to Red
            textColor = UtilsClass.GetColorFromString("FF0000");
        } else if (color.Equals("Green"))
        {
            //Set Text color to Green
            textColor = UtilsClass.GetColorFromString("0BFF04");
        } else if (color.Equals("Orange"))
        {
            //Set Text color to Orange
            textColor = UtilsClass.GetColorFromString("FFA500");
        }
        textColor = textMesh.color;
        disappearTimer = DISAPPEAR_TIME_MAX;

        moveVector = new Vector3(1, 1) * 8f;
    }

    private void Update()
    {
        gameObject.transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 7f * Time.deltaTime;

        if(disappearTimer > DISAPPEAR_TIME_MAX * 0.5f)
        {
            //First half of popup lifetime
            float increaseScaleAmount = 0.05f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        } else
        {
            //2nd half of popup lifetime
            float decreaseScaleAmount = 0.05f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            //Start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
