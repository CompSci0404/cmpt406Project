using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBread : ItemClass
{
    private GameObject playerCont;

    // Start is called before the first frame update
    void Start()
    {
        itemEffect = UseBatteryBread;
        playerCont = GameObject.FindWithTag("Player");
        SetUsable(true);
    }

    public void UseBatteryBread()
    {
        //sound effect
        FindObjectOfType<AudioManager>().PlaySound("itemConsumed");

        if (playerCont.GetComponent<Abilities>().aAvailable)
        {
            Debug.Log("NO ABILITY");
        }
        else
        {
            // will not work until room cooldown is implemented
            playerCont.GetComponent<Abilities>().GetActiveAbility().GetComponentInChildren<ItemClass>().SetAbilityCooldown(0);
        }
        
    }
}
