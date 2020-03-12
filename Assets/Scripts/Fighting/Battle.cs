using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    // Here i'd check if you should make the attributes public
    public healthBar playerHealth;
    public healthBar monsterHealth;
    public Dice playerDice;
    public Dice monsterDice;

    private void Update()
    {
    }

    public void Fight()
    {
        Debug.Log("MONSTER ROLL: " + monsterDice.diceValue);
        Debug.Log("HERO ROLL: " + playerDice.diceValue);

        if (monsterDice.diceValue > playerDice.diceValue)
        {
            float oppRollValue = monsterDice.diceValue;
            float dec = (oppRollValue / 10f);
            playerHealth.Fill -= dec;
        }
        else if (monsterDice.diceValue < playerDice.diceValue)
        {
            float myRollValue = playerDice.diceValue;
            float dec = (myRollValue / 10f);
            monsterHealth.Fill -= dec;
        }
        else if (monsterDice.diceValue == playerDice.diceValue)
        {
            monsterHealth.Fill -= 0;
            playerHealth.Fill -= 0;
        }
    }

}
