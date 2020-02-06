using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float move_speed = 5f;

    public Rigidbody2D r_body;

    Vector2 movement;


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
    }
}
