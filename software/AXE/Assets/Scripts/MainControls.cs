﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        // Get movement script from this object
        for (int i = 0; i < transform.childCount; i++)
        {
            players.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // wait for an input and set opposite player controller active
        if (Input.GetButtonDown(yButton)) {
            stats.gameObject.SetActive(false);
            GameObject nextPlayer = players[0];
            nextPlayer.SetActive(true);
            players.Remove(nextPlayer);
            players.Add(nextPlayer);
        };
        
        // player has a method that activates when it becomes active and sends its stats to this class
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
