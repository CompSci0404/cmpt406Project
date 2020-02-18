﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float move_speed = 5f;

    public Rigidbody2D r_body;
    public GameObject player; 

    Vector2 movement;

    private PlayerStats stat;
    void Start()
    {
        stat = this.GetComponent<PlayerStats>();
    }

    public void DmgPlyer(float dmg)
    {
        float health = stat.GetHealth();

        health -= dmg;

        stat.SetHealth(health);

        if (stat.GetHealth() <= 0)
        {


            Death();
        }
    }

    private void Death()
    {
        Debug.Log("wah I am dead :(");

        Destroy(player,5.5f); 
    }

    // Update is called once per frame and gets users inputs
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.magnitude > 1)
        {
            movement.Normalize();
        }
    }

    // After the update frame gets the users input, fixed update will move the player.
    private void FixedUpdate()
    {
        
        if (movement.x == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        r_body.MovePosition(r_body.position + movement * move_speed * Time.fixedDeltaTime);

        //var gamepad = Gamepad.current;
        //if (gamepad == null)
        //    return; // No gamepad connected.

        //if (gamepad.rightTrigger.wasPressedThisFrame)
        //{
        //    // 'Use' code here
        //}

        //Vector2 move = gamepad.leftStick.ReadValue();
    }
}
