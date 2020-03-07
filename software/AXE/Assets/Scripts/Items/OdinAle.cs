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
    }

    void AddHealth()
    {
        if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1)
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
    }
}