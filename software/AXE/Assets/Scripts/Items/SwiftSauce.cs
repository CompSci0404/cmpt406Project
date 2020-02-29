using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiftSauce : ItemClass
{
    private GameObject playerCont;
    void Start()
    {
        itemEffect = increaseSpeed;
        playerCont = GameObject.FindWithTag("Player");
    }

    public void increaseSpeed()
    {
        if (playerCont.GetComponent<MainControls>().getControllerNumber() == 1)
        {
            playerCont = GameObject.FindWithTag("Thor");
        }
        else
        {
            playerCont = GameObject.FindWithTag("Type2");
        }
        
        float attackSpeed = playerCont.GetComponent<PlayerStats>().GetAttackSpeed();
        float moveSpeed = playerCont.GetComponentInParent<PlayerStats>().GetMoveSpeed();
        Debug.Log(playerCont.GetComponentInParent<PlayerStats>().GetMoveSpeed());
        playerCont.GetComponent<PlayerStats>().SetAttackSpeed(attackSpeed * 1.5f);
        playerCont.GetComponent<PlayerStats>().SetMoveSpeed(moveSpeed * 1.5f);
        Debug.Log(playerCont.GetComponentInParent<PlayerStats>().GetMoveSpeed());
    }
}
