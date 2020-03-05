﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerInput))]


public class PlayerManager : MonoBehaviour
{
    public PlayerMover playerMover;
    public PlayerInput playerInput;
    


    private void Awake()
    {
        playerMover = GetComponent<PlayerMover>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.InputEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Ignore player input if user is moving
        if(playerMover.isMoving)
        {
            return;
        }

        //get Keyboard input
        playerInput.GetKeyInput();

        if(playerInput.V == 0)
        {
            if (playerInput.H < 0) { playerMover.MoveLeft(); }
            else if (playerInput.H > 0) { playerMover.MoveRight(); }
        } else if (playerInput. H == 0)
        {
            if (playerInput.V < 0)
            {
                playerMover.MoveBackward();
            }else if (playerInput.V > 0)
            {
                playerMover.MoveForward();
            }
        }
    }
}
