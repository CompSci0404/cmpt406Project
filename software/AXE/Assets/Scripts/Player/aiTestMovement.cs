using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiTestMovement : MonoBehaviour
{
    public float sensorLength = 10.0f;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;



    void FixedUpdate()
    {
         movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.AddForce(movement * moveSpeed);
    }


   
}
