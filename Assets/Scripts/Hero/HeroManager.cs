using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(HeroMover))]
[RequireComponent(typeof(HeroInput))]


public class HeroManager : MonoBehaviour
{
    public HeroMover heroMover;
    public HeroInput heroInput;



    private void Awake()
    {
        heroMover = GetComponent<HeroMover>();
        heroInput = GetComponent<HeroInput>();
        heroInput.InputEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Ignore player input if user is moving
        if (heroMover.isMoving)
        {
            return;
        }

        //get Keyboard input
        heroInput.GetKeyInput();

        if (heroInput.V == 0)
        {
            if (heroInput.H < 0) { heroMover.MoveLeft(); }
            else if (heroInput.H > 0) { heroMover.MoveRight(); }
        }
        else if (heroInput.H == 0)
        {
            if (heroInput.V < 0)
            {
                heroMover.MoveBackward();
            }
            else if (heroInput.V > 0)
            {
                heroMover.MoveForward();
            }
        }
    }
}