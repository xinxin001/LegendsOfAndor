using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dice : MonoBehaviour
{
    Rigidbody rb;

    public bool hasLanded;
    public bool thrown;

    Vector3 initPosition;

    public int diceValue;

    public DiceSide[] diceSides;


    public Dice opposingDice;
    public healthBar opponentHealth;
    public healthBar myHealth;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(2);
        }

        if(rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            SideValueCheck();

        }else if(rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            RollAgain();
        }
    }

    void RollDice()
    {
        if(!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }
        else if(thrown && hasLanded)
        {
            Reset();
            Battle();

        }
    }

    private void Reset()
    {
        transform.position = initPosition;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }

    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    void SideValueCheck()
    {
        diceValue = 0;
        foreach(DiceSide side in diceSides)
        {
            if (side.OnGround() && hasLanded)
            {
                diceValue = side.sideValue;
            }
        }
    }

    void Battle()
    {

        Debug.Log(diceValue + " has been rolled");
        Debug.Log(opposingDice.diceValue + " OPPONENT");

        if (opposingDice.diceValue > diceValue)
        {
            float oppRollValue = opposingDice.diceValue;
            float dec = (oppRollValue / 10f);
            myHealth.Fill -= dec;
        }
        else if (opposingDice.diceValue < diceValue)
        {
            float rollValue = diceValue;
            float decrement = (rollValue / 10f);
            opponentHealth.Fill -= decrement;
        }
        else if (opposingDice.diceValue == diceValue)
        {
            opponentHealth.Fill -= 0;
            myHealth.Fill -= 0;
        }
    }
}
