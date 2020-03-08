using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Image Bar;
    public float Fill;
    public Dice opposingDice;
    public Dice myDice;

    // Start is called before the first frame update
    void Start()
    {
        Fill = 1f;
    }

    //THIS IS BUGGY AF
    // Update is called once per frame
    void Update()
    {
        if(opposingDice.diceValue > myDice.diceValue)
        {
            float decrement = ((opposingDice.diceValue) / 10f);
            Bar.fillAmount = Bar.fillAmount - decrement;
        }
        else
        {
            Bar.fillAmount = Bar.fillAmount;
        }
    }
}
