﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainControls : MonoBehaviour
{
    private PlayerStats stats;

    private string horizontalAxis;
    private string verticalAxis;
    private string aButton;
    private string bButton;
    private string xButton;
    private string yButton;
    private int controllerNumber;

    private List<GameObject> players;

    // Start is called before the first frame update
    void Awake()
    {
        players = new List<GameObject>();
        // Get movement script from this object
        for (int i = 0; i < transform.childCount; i++)
        {
            players.Add(transform.GetChild(i).gameObject);
        }

        SwapPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        // wait for an input and set opposite player controller active
        if (Input.GetButtonDown(yButton)) {
            SwapPlayer();
        }

        else if (Input.GetButtonDown(bButton))
        {
            Attack();
        }
        else if (Input.GetButtonDown(aButton))
        {
            Ability1();
        }
        else if (Input.GetButtonDown(xButton))
        {
            Ability2();
        }

        // player has a method that activates when it becomes active and sends its stats to this class
    }

    private void SwapPlayer()
    {
        Debug.Log("SwapPlayer()");

        if (null != stats) stats.gameObject.SetActive(false);
        GameObject nextPlayer = players[0];
        nextPlayer.SetActive(true);

        players.Remove(nextPlayer);
        players.Add(nextPlayer);

    }

    // Normal Attack
    private void Attack()
    {
        
        // if player 1 melee

        if (controllerNumber == 1)
        {
            this.GetComponent<MeleeAttack>().MlAttack();
            Debug.Log("Player 1 Melee Attacking");
        }
        // if player 2 range
        else if (controllerNumber == 2)
        {
            Debug.Log("Player 2 Range Attacking");
        }
        
    }

    // Ability 1
    private void Ability1()
    {

        // if player 1 use P1 A1
        if (controllerNumber == 1)
        {
            Debug.Log("Player 1 uses Ability 1");
        }
        // if player 2 range
        else if (controllerNumber == 2)
        {
            Debug.Log("Player 2 uses Ability 1");
        }
        // if player 2 use P2 A1
    }

    // Ability 2
    private void Ability2()
    {
        // if player 1 use P1 A2
        if (controllerNumber == 1)
        {
            Debug.Log("Player 1 uses Ability 2");
        }
        // if player 2 range
        else if (controllerNumber == 2)
        {
            Debug.Log("Player 2 uses Ability 2");
        }
        // if player 2 use P2 A2
    }

    public void UpdateStats(PlayerStats stats)
    {
        // update the movement script with variables from player
        this.stats = stats;
        SetPlayerNumber(stats.GetControllerNumber());
    }

    private void SetPlayerNumber(int number)
    {
        controllerNumber = number;
        horizontalAxis = "J" + controllerNumber + "Horizontal";
        verticalAxis = "J" + controllerNumber + "Vertical";
        aButton = "J" + controllerNumber + "A";
        bButton = "J" + controllerNumber + "B";
        xButton = "J" + controllerNumber + "X";
        yButton = "J" + controllerNumber + "Y";
    }

}
