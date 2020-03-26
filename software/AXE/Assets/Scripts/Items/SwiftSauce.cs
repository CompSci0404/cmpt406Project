using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiftSauce : ItemClass
{
    private GameObject playerCont;
    void Start()
    {
        itemEffect = IncreaseSpeed;
        playerCont = GameObject.FindWithTag("Player");
        SetUsable(true);
    }

    public void IncreaseSpeed()
    {
        float attackSpeed;
        float moveSpeed;
        GameObject player;

        //SoundEffect
        FindObjectOfType<AudioManager>().PlaySound("itemConsumed");

        if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 1)
        {
            Debug.Log("increasing p1");
            player = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject;
            Debug.Log(player);
            attackSpeed = player.GetComponent<PlayerStats>().GetAttackSpeed();
            moveSpeed = player.GetComponent<PlayerStats>().GetMoveSpeed();
            Debug.Log(attackSpeed + " " + moveSpeed);

            player.GetComponent<PlayerStats>().SetAttackSpeed(attackSpeed * GetItemMultiplier());
            player.GetComponent<PlayerStats>().SetMoveSpeed(moveSpeed * GetItemMultiplier());
            Debug.Log(player.GetComponent<PlayerStats>().GetAttackSpeed() + " " + player.GetComponent<PlayerStats>().GetMoveSpeed());
            SetPlayerItemUsed(1);
        }
        else if (playerCont.GetComponent<MainControls>().GetControllerNumber() == 2)
        {
            Debug.Log("increasing p2");
            player = GameObject.FindWithTag("Player").transform.GetChild(1).gameObject;
            float attackSpeed2 = player.GetComponent<PlayerStats>().GetAttackSpeed();
            float moveSpeed2 = player.GetComponent<PlayerStats>().GetMoveSpeed();
            Debug.Log(attackSpeed2 + " " + moveSpeed2);
            player.GetComponent<PlayerStats>().SetAttackSpeed(attackSpeed2 * GetItemMultiplier());
            player.GetComponent<PlayerStats>().SetMoveSpeed(moveSpeed2 * GetItemMultiplier());
            Debug.Log(player.GetComponent<PlayerStats>().GetAttackSpeed() + " " + player.GetComponent<PlayerStats>().GetMoveSpeed());
            SetPlayerItemUsed(2);
        }
        /*
        player = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject;
        attackSpeed = player.GetComponent<PlayerStats>().GetAttackSpeed();
        moveSpeed = player.GetComponent<PlayerStats>().GetMoveSpeed();
        player.GetComponent<PlayerStats>().SetAttackSpeed(attackSpeed * getItemMultiplier());
        player.GetComponent<PlayerStats>().SetMoveSpeed(moveSpeed * getItemMultiplier());

        player = GameObject.FindWithTag("Player").transform.GetChild(1).gameObject;
        float attackSpeed2 = player.GetComponent<PlayerStats>().GetAttackSpeed();
        float moveSpeed2 = player.GetComponent<PlayerStats>().GetMoveSpeed();
        player.GetComponent<PlayerStats>().SetAttackSpeed(attackSpeed2 * getItemMultiplier());
        player.GetComponent<PlayerStats>().SetMoveSpeed(moveSpeed2 * getItemMultiplier());
        */
    }

    
}
