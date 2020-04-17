using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdinAle: ItemClass
{
    private PlayerStats stats;

    private bool used = false;

    private GameObject playerCont;
    void Start()
    {
        itemEffect = AddHealth;
        playerCont = GameObject.FindWithTag("Player");
        SetUsable(true);
    }

    void AddHealth()
    {
        if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 1)
        {
            playerCont = GameObject.FindWithTag("Thor");
        }
        else
        {
            playerCont = GameObject.FindWithTag("Type2");
        }
        used = true;
        stats = playerCont.GetComponent<PlayerStats>();
        int maxHearts = stats.GetMaxHearts();
        stats.SetCurrHearts(maxHearts);
        stats.ResetHearts();

        //sound effect
        FindObjectOfType<AudioManager>().PlaySound("itemConsumed");
    }
}