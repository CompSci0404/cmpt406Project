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
    }

    // After the update frame gets the users input, fixed update will move the player.
    private void FixedUpdate()
    {
        if (movement.x == -1)
        {
            //transform.localScale = new Vector3(-1, 1, 1);
            //this.GetComponent<SpriteRenderer>().flipX = true;
            //Transform weaponT = transform.GetChild(0);

            //Vector3 weaponFlip = new Vector3(transform.position.x - 0.6f, transform.position.y, transform.position.z);
            //weaponT.position = weaponFlip;

            //weaponT.Rotate(0f, 0f, 43.062f);
            
        }
        else if (movement.x == 1)
        {
            //this.GetComponent<SpriteRenderer>().flipX = false;

            //Transform weaponT = transform.GetChild(0);

            //Vector3 weaponFlip = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            //weaponT.position = weaponFlip;

            //weaponT.Rotate(0f, 0f, -43.955f);
        }
        r_body.MovePosition(r_body.position + movement * move_speed * Time.fixedDeltaTime);
    }
}
