using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDiceValue : MonoBehaviour
{
    public dice2 dice1;
    public dice2 dice2;
    public int diceValue;
    public bool turnDone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(dice1.isRolled && dice2.isRolled)
        {
            turnDone = true;
        }
        if (!dice1.isRolled || !dice2.isRolled)
        {
            turnDone = false;
        }

        if (dice1.isRolled && dice2.isRolled)
        {
            diceValue = computeAttackPower();
        }


    }

    public int computeAttackPower()
    {
        int val1 = dice1.getValue();
        int val2 = dice2.getValue();
        int highestRoll;
        if (val1 > val2) { highestRoll = val1; } else { highestRoll = val2; }
        int attackPower = highestRoll;
        return attackPower;
    }

}
