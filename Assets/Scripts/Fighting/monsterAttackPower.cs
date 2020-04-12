using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterAttackPower : MonoBehaviour
{
    public dice2 dice1;
    public dice2 dice2;
    public Monster monster;
    public int attackValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (dice1.isRolled && dice2.isRolled)
        {
            attackValue = computeAttackPower();
            dice1.isRolled = false;
            dice2.isRolled = false;
        }

    }

    public int computeAttackPower()
    {
        int val1 = dice1.getValue();
        int val2 = dice2.getValue();
        int highestRoll;
        if (val1 > val2) { highestRoll = val1; } else { highestRoll = val2; }
        int attackPower = highestRoll + monster.strength;
        return attackPower;
    }
}
